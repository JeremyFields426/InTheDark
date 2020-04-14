using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName ="Item/Weapon/Firearm/Standard")]
public class FirearmData : RefillableItemData
{
    [Header("Projectile Info")]
    [SerializeField] private ProjectileData projectileData = null;

    [Header("Reloading Info")]
    [SerializeField] private int startingAmmo = 0;
    [SerializeField] private int maxMagCapacity = 15;

    [Header("Fire Settings")]
    [SerializeField] private float fireCooldown = 0.30f;

    [Header("Effects")]
    [SerializeField] private GameObject muzzleFlashPrefab = null;
    [SerializeField] private Sound shootSound = null;
    [SerializeField] private Sound reloadSound = null;


    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Primary;

    public ProjectileData ProjectileData => projectileData;

    public int StartingAmmo => startingAmmo;

    public int MaxMagCapacity => maxMagCapacity;

    public float FireCooldown => fireCooldown;

    public GameObject MuzzleFlashPrefab => muzzleFlashPrefab;

    public Sound ShootSound => shootSound;

    public Sound ReloadSound => reloadSound;


    public override string GetRefillInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Ammo Refill: ").Append(MaxMagCapacity).Append(MaxMagCapacity == 1 ? " Round" : " Rounds").AppendLine();

        return builder.ToString();
    }

    public override string GetInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Description: ").Append(Description).AppendLine();
        builder.Append("Fire Rate: ").Append(Mathf.Round((1f / FireCooldown) * 10f) / 10f).Append(FireCooldown == 1 ? " Round" : " Rounds").Append(" Per Sec").AppendLine();
        builder.Append("Projectile Damage: ").Append(ProjectileData.Damage).AppendLine();
        builder.Append("Projectile Speed: ").Append(ProjectileData.Speed).AppendLine();
        builder.Append("Magazine Capacity: ").Append(MaxMagCapacity).Append(MaxMagCapacity == 1 ? " Round" : " Rounds").AppendLine();
        builder.Append("Starting Ammo: ").Append(StartingAmmo + MaxMagCapacity).Append(StartingAmmo + MaxMagCapacity == 1 ? " Round" : " Rounds").AppendLine();

        return builder.ToString();
    }
}
