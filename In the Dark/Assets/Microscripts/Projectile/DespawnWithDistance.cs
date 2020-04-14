using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DespawnWithDistance : DespawnThisObject
{
    private Rigidbody2D rb;

    private Vector3 startPos;

    [SerializeField] private ProjectileData projectileData = null;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        startPos = Vector3.one;
    }

    private void Update()
    {
        if (startPos == Vector3.one)
        {
            if (!Mathf.Approximately(rb.velocity.magnitude, 0f))
            {
                startPos = transform.position;
            }
        }
        else if (!transform.WithinDistanceOf(startPos, projectileData.MaxTravelDistance))
        {
            Despawn();
        }
    }
}
