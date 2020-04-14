using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName = "Item/Weapon/Throwable/Standard")]
public class ThrowableData : RefillableItemData
{
    [Header("Projectile Info")]
    [SerializeField] private ProjectileData projectileData = null;
    [SerializeField] private int startingAmount = 5;

    [Header("Throwing Settings")]
    [SerializeField] private float throwCooldown = 1f;

    [Header("Effects")]
    [SerializeField] private Sound throwSound = null;


    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Secondary;

    public ProjectileData ProjectileData => projectileData;

    public int StartingAmount => startingAmount;

    public float ThrowCooldown => throwCooldown;

    public Sound ThrowSound => throwSound;


    public override string GetRefillInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Throwable Refill: ").Append(1).Append(" Throwable").AppendLine();

        return builder.ToString();
    }

    public override string GetInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Description: ").Append(Description).AppendLine();
        builder.Append("Damage: ").Append(ProjectileData.Damage).AppendLine();
        builder.Append("Speed: ").Append(ProjectileData.Speed).AppendLine();
        builder.Append("Max Distance: ").Append(ProjectileData.MaxTravelDistance).AppendLine();
        builder.Append("Starting Amount: ").Append(StartingAmount).Append(StartingAmount == 1f ? " Throwable" : " Throwables").AppendLine();

        return builder.ToString();
    }
}
