using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Collider2D))]
public class CallEventsOnAnyTrigger : MonoBehaviour
{
    private int currentTriggerAmount;

    [SerializeField] [Min(1f)] private int triggerAmountBeforeCalls = 1;
    [SerializeField] private bool callEventsOnce = false;
    [SerializeField] private TriggerCallback onTrigger = null;


    private void OnEnable()
    {
        currentTriggerAmount = triggerAmountBeforeCalls;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentTriggerAmount--;

        if (currentTriggerAmount == 0 || (currentTriggerAmount < 0 && !callEventsOnce))
        {
            onTrigger?.Invoke(collision.gameObject);
        }
    }
}

[Serializable]
public class TriggerCallback : UnityEvent<GameObject> { }
