using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    [SerializeField] private ProjectileData projectileData = null;


    public void InflictDamageOnTarget(GameObject target)
    {
        if (target.TryGetComponent(out ITakeDamage targetHealth))
        {
            targetHealth.TakeDamage(projectileData.Damage);
        }
    }
}
