using UnityEngine;

public class InflictDamageInRadius : MonoBehaviour
{
    [SerializeField] private AOEProjectileData aoeProjectileData = null;


    public void DamageTargetsInRadius(bool useDeltaTime)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, aoeProjectileData.AreaOfEffectRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out ITakeDamage target) && aoeProjectileData.TargetTypes.Contains(target.TargetType))
            {
                target.TakeDamage(aoeProjectileData.Damage * (useDeltaTime ? Time.deltaTime : 1f));
            }
        }
    }
}
