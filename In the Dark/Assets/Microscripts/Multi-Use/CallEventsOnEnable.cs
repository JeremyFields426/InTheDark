using UnityEngine;
using UnityEngine.Events;

public class CallEventsOnEnable : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnable = null;


    private void OnEnable()
    {
        onEnable?.Invoke();
    }
}
