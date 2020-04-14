using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GrowWithMouseClick : MonoBehaviour
{
    private Vector2 startingSize;

    [SerializeField] private float maxGrowthTimes = 5f;
    [SerializeField] private float growthAmountPerSecond = 2f;

    private void Awake()
    {
        startingSize = transform.localScale;
    }

    private void OnEnable()
    {
        transform.localScale = startingSize;

        StartCoroutine(CheckMouseClick());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckMouseClick());
    }

    private IEnumerator CheckMouseClick()
    {
        while (Mouse.current.leftButton.isPressed && ((Vector2)transform.localScale).magnitude < startingSize.magnitude * maxGrowthTimes)
        {
            transform.localScale += new Vector3(
                growthAmountPerSecond * Time.deltaTime,
                growthAmountPerSecond * Time.deltaTime
            );

            yield return null;
        }
    }
}
