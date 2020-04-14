using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ClearTrail : MonoBehaviour
{
    private TrailRenderer trail;


    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        trail.Clear();
    }
}
