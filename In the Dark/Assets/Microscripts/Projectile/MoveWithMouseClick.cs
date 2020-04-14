using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithMouseClick : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private ProjectileData projectileData = null;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(CheckMouseClick());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckMouseClick());
    }

    private IEnumerator CheckMouseClick()
    {
        while (Mouse.current.leftButton.isPressed) { yield return null; }

        rb.velocity = transform.right * projectileData.Speed;
    }
}
