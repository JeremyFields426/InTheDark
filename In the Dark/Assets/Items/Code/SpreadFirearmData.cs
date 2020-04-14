using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon/Firearm/Spread")]
public class SpreadFirearmData : FirearmData
{
    [Header("Additional Fire Settings")]
    [SerializeField] private int numberOfProjectiles = 3;
    [SerializeField] private float angleBetweenProjectiles = 5f;


    public int NumberOfProjectiles => numberOfProjectiles;

    public float AngleBetweenProjectiles => angleBetweenProjectiles;
}
