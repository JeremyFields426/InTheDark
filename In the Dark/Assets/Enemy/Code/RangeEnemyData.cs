using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Spitter")]
public class RangeEnemyData : EnemyData
{
    [Header("Attacking Info")]
    [SerializeField] private ProjectileData projectileData = null;
    [SerializeField] private float fireCooldown = 0.25f;
    [SerializeField] private float attackDistance = 7f;


    public ProjectileData ProjectileData => projectileData;

    public float FireCooldown => fireCooldown;

    public float AttackDistance => attackDistance;
}
