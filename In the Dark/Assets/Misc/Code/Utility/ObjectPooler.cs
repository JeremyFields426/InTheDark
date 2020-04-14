using UnityEngine;
using System;
using System.Collections.Generic;

public static class ObjectPooler
{
    public static event Action<GameObject> ObjectCreatedCallback;

    private const int DEFAULT_POOL_SIZE = 5;
    private static Dictionary<GameObject, Pool> pools;


    private static void Initialize(GameObject prefab = null, int qty = DEFAULT_POOL_SIZE)
    {
        if (pools == null)
        {
            pools = new Dictionary<GameObject, Pool>();
        }

        if (prefab != null && !pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new Pool(prefab, qty));
        }
    }

    public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Spawn(prefab, position, rotation, null);
    }

    public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        Initialize(prefab);

        return pools[prefab].Spawn(position, rotation, parent);
    }

    public static GameObject Create(GameObject prefab, Transform parent)
    {
        GameObject obj = UnityEngine.Object.Instantiate(prefab, GetParent(parent));
        ObjectCreatedCallback?.Invoke(obj);
        return obj;
    }

    public static GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Create(prefab, position, rotation, null);
    }

    public static GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject obj = UnityEngine.Object.Instantiate(prefab, position, rotation, GetParent(parent));
        ObjectCreatedCallback?.Invoke(obj);
        return obj;
    }

    public static void Despawn(GameObject obj)
    {
        PoolMember pm = obj.GetComponent<PoolMember>();

        if (pm != null)
        {
            pm.MyPool.Despawn(obj);
        }
        else
        {
            UnityEngine.Object.Destroy(obj);
        }
    }

    public static Transform GetParent(Transform parent)
    {
        if (parent == null)
        {
            GameObject spawnedObjectsParent = GameObject.Find("SpawnedObjects");

            if (spawnedObjectsParent == null)
            {
                return new GameObject("SpawnedObjects").transform;
            }

            return spawnedObjectsParent.transform;
        }

        return parent;
    }

    private class PoolMember : MonoBehaviour
    {
        public Pool MyPool { get; set; }
    }

    private class Pool
    {
        private GameObject prefab;
        private Stack<GameObject> inactiveObjects;

        public Pool(GameObject prefab, int initialQty)
        {
            this.prefab = prefab;

            inactiveObjects = new Stack<GameObject>(initialQty);
        }

        public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent)
        {
            GameObject obj;

            if (inactiveObjects.Count == 0)
            {
                obj = UnityEngine.Object.Instantiate(prefab, position, rotation, GetParent(parent));
                obj.AddComponent<PoolMember>().MyPool = this;

                ObjectCreatedCallback?.Invoke(obj);
            }
            else
            {
                obj = inactiveObjects.Pop();
                obj.transform.parent = GetParent(parent);
                obj.transform.position = position;
                obj.transform.rotation = rotation;

                if (obj == null)
                {
                    return Spawn(position, rotation, parent);
                }
            }

            obj.SetActive(true);
            return obj;
        }

        public void Despawn(GameObject obj)
        {
            obj.SetActive(false);

            inactiveObjects.Push(obj);
        }
    }
}
