using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ReturnObjectToSender : MonoBehaviour
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
        startPos = transform.position;

        StartCoroutine(CheckDistanceFromSender());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckDistanceFromSender());
    }

    private IEnumerator CheckDistanceFromSender()
    {
        while (transform.WithinDistanceOf(startPos, projectileData.MaxTravelDistance)) { yield return null; }

        ReturnToSender();
    }

    public void ReturnToSender()
    {
        StopCoroutine(CheckDistanceFromSender());
        transform.rotation = Quaternion.Euler(0f, 0f, transform.Angle(startPos));
        rb.velocity = transform.right * projectileData.Speed;
        StartCoroutine(CheckDistanceToSender());
    }

    private IEnumerator CheckDistanceToSender()
    {
        while (!transform.WithinDistanceOf(startPos, 1f)) { yield return null; }

        rb.velocity = Vector2.zero;
    }
}
