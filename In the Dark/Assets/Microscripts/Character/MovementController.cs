using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IHaveDirection))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private IHaveDirection directionInput;

    private Vector3 referenceVelocity;

    [SerializeField] [Range(0f, 1f)] private float smoothing = 0.05f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        directionInput = GetComponent<IHaveDirection>();
    }

    private void FixedUpdate()
    {
        Move(directionInput.Direction);
    }

    private void Move(Vector2 direction)
    {
        rb.angularVelocity = 0f;

        rb.velocity = Vector3.SmoothDamp(rb.velocity, direction * Time.fixedDeltaTime, ref referenceVelocity, smoothing);
    }
}
