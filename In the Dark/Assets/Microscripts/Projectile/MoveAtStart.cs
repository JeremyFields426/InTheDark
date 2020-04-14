using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveAtStart : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private ProjectileData projectileData = null;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        rb.velocity = transform.right * projectileData.Speed;
    }
}
