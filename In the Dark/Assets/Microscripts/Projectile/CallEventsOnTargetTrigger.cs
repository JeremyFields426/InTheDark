using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CallEventsOnTargetTrigger : MonoBehaviour
{
    private int currentTriggerAmount;

    [SerializeField] [Min(1f)] private int triggerAmountUntilCalls = 1;
    [SerializeField] private bool callEventsOnce = true;
    [SerializeField] private ProjectileData projectileData = null;
    [SerializeField] private TriggerCallback onTrigger = null;


    private void OnEnable()
    {
        currentTriggerAmount = triggerAmountUntilCalls;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IAmTarget target) && projectileData.TargetTypes.Contains(target.TargetType))
        {
            currentTriggerAmount--;

            if (currentTriggerAmount == 0 || (currentTriggerAmount < 0 && !callEventsOnce))
            {
                onTrigger?.Invoke(collision.gameObject);
            }
        }
    }
}
