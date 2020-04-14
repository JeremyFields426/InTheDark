using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Transform hook = null;
    [SerializeField] private Transform lamp = null;
    

    private void FixedUpdate()
    {
        lamp.transform.rotation = Quaternion.Euler(0f, 0f, hook.Angle(lamp) + 90f);
    }
}
