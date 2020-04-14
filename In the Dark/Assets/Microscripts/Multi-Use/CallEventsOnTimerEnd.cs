using UnityEngine;
using UnityEngine.Events;

public class CallEventsOnTimerEnd : MonoBehaviour
{
    private float timeLeft;

    [SerializeField] private UnityEvent onTimerEnd = null;
    [SerializeField] private float timerDuration = 5f;


    private void OnEnable()
    {
        timeLeft = timerDuration;
    }

    private void Update()
    {
        Tick(Time.deltaTime);
    }

    private void Tick(float deltaTime)
    {
        if (timeLeft == 0f) { return; }

        timeLeft -= deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;

            onTimerEnd?.Invoke();
        }
    }
}
