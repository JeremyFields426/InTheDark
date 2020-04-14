using UnityEngine;

[RequireComponent(typeof(IFindTarget))]
public class TrapAttack : MonoBehaviour
{
    private IFindTarget targetSystem;

    [SerializeField] private TrapEnemyData trapEnemyData = null;


    private void Awake()
    {
        targetSystem = GetComponent<IFindTarget>();
    }

    private void Update()
    {
        if (transform.InLineOfSightOf(targetSystem.Target, trapEnemyData.AttackDistance))
        {
            ObjectPooler.Spawn(trapEnemyData.TrapData.Prefab, transform.position, Quaternion.identity);
            ObjectPooler.Despawn(gameObject);
        }
    }
}
