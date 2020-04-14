using UnityEngine;

[RequireComponent(typeof(IFindTarget))]
public class MultiRangeAttack : MonoBehaviour
{
    private IFindTarget targetSystem;

    private float currentFireCooldown;

    [SerializeField] private MultiRangeEnemyData multiRangeEnemyData = null;


    private void Awake()
    {
        targetSystem = GetComponent<IFindTarget>();
    }

    private void OnEnable()
    {
        currentFireCooldown = Time.time + multiRangeEnemyData.FireCooldown;
    }

    private void Update()
    {
        if (Time.time > currentFireCooldown && transform.InLineOfSightOf(targetSystem.Target, multiRangeEnemyData.AttackDistance))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        float currentAngle = Random.Range(0f, 360f);

        for (int i = 0; i < multiRangeEnemyData.NumberOfProjectiles; i++)
        {
            ObjectPooler.Spawn(
                multiRangeEnemyData.ProjectileData.Prefab, 
                transform.position,
                Quaternion.Euler(0f, 0f, currentAngle));

            currentAngle += 360f / multiRangeEnemyData.NumberOfProjectiles;
        }

        currentFireCooldown = Time.time + multiRangeEnemyData.FireCooldown;
    }
}
