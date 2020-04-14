using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class StopWithDistance : MonoBehaviour
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

        StartCoroutine(CheckDistance());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (transform.WithinDistanceOf(startPos, projectileData.MaxTravelDistance)) { yield return null; }
        
        rb.velocity = Vector2.zero;
    }
}
