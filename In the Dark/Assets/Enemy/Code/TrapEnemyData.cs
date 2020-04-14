using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Melter")]
public class TrapEnemyData : EnemyData
{
    [Header("Attacking Info")]
    [SerializeField] private ProjectileData trapData = null;
    [SerializeField] private float attackDistance = 1f;


    public ProjectileData TrapData => trapData;

    public float AttackDistance => attackDistance;
}
