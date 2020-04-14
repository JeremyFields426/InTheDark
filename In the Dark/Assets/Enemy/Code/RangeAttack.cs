using UnityEngine;

[RequireComponent(typeof(IFindTarget))]
[RequireComponent(typeof(IHaveAngle))]
public class RangeAttack : MonoBehaviour
{
    private IFindTarget targetSystem;
    private IHaveAngle angleInput;

    private float currentFireCooldown;

    [SerializeField] private Transform firepoint = null;
    [SerializeField] private RangeEnemyData rangeEnemyData = null;


    private void Awake()
    {
        targetSystem = GetComponent<IFindTarget>();
        angleInput = GetComponent<IHaveAngle>();
    }

    private void OnEnable()
    {
        currentFireCooldown = Time.time + rangeEnemyData.FireCooldown;
    }

    private void Update()
    {
        if (Time.time > currentFireCooldown && transform.InLineOfSightOf(targetSystem.Target, rangeEnemyData.AttackDistance))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ObjectPooler.Spawn(rangeEnemyData.ProjectileData.Prefab, firepoint.position,  Quaternion.Euler(0f, 0f, angleInput.Angle));

        currentFireCooldown = Time.time + rangeEnemyData.FireCooldown;
    }
}
