using UnityEngine;

[RequireComponent(typeof(IHaveAngle))]
public class RotationController : MonoBehaviour
{
    private IHaveAngle angleInput;

    [SerializeField] private float offset = 1f;


    private void Awake()
    {
        angleInput = GetComponent<IHaveAngle>();
    }

    private void FixedUpdate()
    {
        Rotate(angleInput.Angle);
    }

    public void Rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }
}
