using UnityEngine;

public class SpawnAnObject : MonoBehaviour
{
    public void Spawn(GameObject obj)
    {
        ObjectPooler.Spawn(obj, transform.position, obj.transform.rotation);
    }
}
