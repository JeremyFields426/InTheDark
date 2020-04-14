using UnityEngine;

public class EnemyMovementInput : AiMovementInput, IHaveAngle, IChangeSpeed
{
    private float speedModifier = 1f;

    [SerializeField] private EnemyData enemyData = null;
    [SerializeField] private TargetType targetType = TargetType.Enemy;


    public TargetType TargetType => targetType;

    public float Angle { get; protected set; }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        UpdateAngle();
    }

    protected override void UpdateDirection()
    {
        if (transform.InLineOfSightOf(targetSystem.Target, enemyData.StopDistance))
        {
            Direction = Vector2.zero;
        }
        else
        {
            Direction = transform.DirectionTo(currentPath.vectorPath[currentWaypoint]).normalized;
            Direction *= enemyData.Speed * speedModifier * 10f;
        }
    }

    private void UpdateAngle()
    {
        if (targetSystem.Target != null)
        {
            Angle = transform.Angle(targetSystem.Target);
        }
    }

    public void ChangeSpeed(float multiplier)
    {
        if (multiplier > 0f)
        {
            speedModifier *= multiplier;
        }
    }
}
