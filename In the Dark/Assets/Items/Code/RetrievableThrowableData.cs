using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon/Throwable/Retrievable")]
public class RetrievableThrowableData : ThrowableData
{
    [Header("Retrieving Info")]
    [SerializeField] private float retrieveDistance = 1f;
    [SerializeField] private float retrieveCooldown = 1.5f;
    [SerializeField] private float retrieveTimeout = 5f;


    public float RetrieveDistance => retrieveDistance;

    public float RetrieveCooldown => retrieveCooldown;

    public float RetrieveTimeout => retrieveTimeout;
}
