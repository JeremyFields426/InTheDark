using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class StopWithMousePosition : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 startPos;
    private float endDistance;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        startPos = transform.position;
        endDistance = transform.SqrDistanceTo((Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        
        StartCoroutine(CheckDistance());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (transform.SqrDistanceTo(startPos) < endDistance) { yield return null; }

        rb.velocity = Vector2.zero;
    }
}
