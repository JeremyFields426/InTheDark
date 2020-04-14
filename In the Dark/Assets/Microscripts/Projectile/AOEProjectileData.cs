using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/AOE")]
public class AOEProjectileData : ProjectileData
{
    [Header("AOE Info")]
    [SerializeField] private float areaOfEffectRadius = 5f;


    public float AreaOfEffectRadius => areaOfEffectRadius;
}
