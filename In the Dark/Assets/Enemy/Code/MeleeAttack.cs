using UnityEngine;

[RequireComponent(typeof(IFindTarget))]
public class MeleeAttack : MonoBehaviour
{
    private IFindTarget targetSystem;

    private bool isAttacking;
    private ITakeDamage targetHealth;
    private IChangeSpeed targetMovement;

    [SerializeField] private MeleeEnemyData meleeEnemyData = null;


    private void Awake()
    {
        targetSystem = GetComponent<IFindTarget>();
    }

    private void OnDisable()
    {
        ResetAttack();
    }

    private void Update()
    {
        if (transform.InLineOfSightOf(targetSystem.Target, meleeEnemyData.AttackDistance))
        {
            Attack();
        }
        else
        {
            ResetAttack();
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            if (targetSystem.Target.TryGetComponent(out targetMovement))
            {
                targetMovement.ChangeSpeed(meleeEnemyData.SlowPercentage);
            }

            targetHealth = targetSystem.Target.GetComponent<ITakeDamage>();

            isAttacking = true;
        }

        targetHealth?.TakeDamage(meleeEnemyData.Damage * Time.deltaTime);
    }

    private void ResetAttack()
    {
        if (targetMovement != null)
        {
            targetMovement.ChangeSpeed(1 / meleeEnemyData.SlowPercentage);
            targetMovement = null;
        }

        targetHealth = null;

        isAttacking = false;
    }
}
