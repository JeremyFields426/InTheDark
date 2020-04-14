using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Charger")]
public class MeleeEnemyData : EnemyData
{
    [Header("Attacking Info")]
    [SerializeField] [Range(0f, 1f)] private float slowPercentage = 0.5f;
    [SerializeField] private float damage = 15f;
    [SerializeField] private float attackDistance = 1f;


    public float Damage => damage;

    public float SlowPercentage => slowPercentage;

    public float AttackDistance => attackDistance;
}
