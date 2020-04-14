using UnityEngine;

public class DespawnThisObject : MonoBehaviour
{
    public void Despawn()
    {
        ObjectPooler.Despawn(gameObject);
    }
}
