using UnityEngine;
using System;

public class FlipController : MonoBehaviour
{
    private IHaveAngle angleInput;
    public event Action<float> FlipCallback;

    [SerializeField] private bool shouldFlipY = false;
    [SerializeField] private bool isChild = false;


    private void Awake()
    {
        angleInput = GetComponent<IHaveAngle>();

        if (!isChild || transform.parent == null) { return; }

        if (transform.parent.TryGetComponent(out FlipController parentFC))
        {
            parentFC.FlipCallback += Flip;
        }
    }

    private void FixedUpdate()
    {
        if (isChild || angleInput == null) { return; }

        Flip(angleInput.Angle);
        FlipCallback?.Invoke(angleInput.Angle);
    }

    private void Flip(float angle)
    {
        if (-90f <= angle && angle <= 90f) // If the angle is on the right side of the player.
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), 
                Mathf.Abs(transform.localScale.y), 1f);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1,
                Mathf.Abs(transform.localScale.y) * ((shouldFlipY) ? -1f : 1f), 1f);
        }
    }

    private void OnDestroy()
    {
        if (transform.parent == null) { return; }

        if (isChild && transform.parent.TryGetComponent(out FlipController parentFC))
        {
            parentFC.FlipCallback -= Flip;
        }
    }
}
