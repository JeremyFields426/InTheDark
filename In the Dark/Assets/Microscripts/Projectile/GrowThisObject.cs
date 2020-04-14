using UnityEngine;

public class GrowThisObject : MonoBehaviour
{
    private Vector3 startingSize;

    [SerializeField] private AOEProjectileData projectileData = null;


    private void Awake()
    {
        startingSize = transform.localScale;
    }

    private void OnEnable()
    {
        transform.localScale = startingSize * projectileData.AreaOfEffectRadius;
    }
}
