using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName = "Item/Kit")]
public class KitData : RefillableItemData
{
    [Header("Kit Info")]
    [SerializeField] private int startingAmount = 2;
    [SerializeField] private float kitRestoreRate = 15f;
    [SerializeField] private float kitRestoreAmount = 50f;
    [SerializeField] private StatType statType = StatType.Health;


    public StatType StatType => statType;

    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Secondary;

    public int StartingAmount => startingAmount;

    public float KitRestoreRate => kitRestoreRate;

    public float KitRestoreAmount => kitRestoreAmount;


    public override string GetRefillInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Kit Refill: ").Append(1).Append(" Kit").AppendLine();

        return builder.ToString();
    }

    public override string GetInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Description: ").Append(Description).AppendLine();
        builder.Append("Restore Amount: ").Append(KitRestoreAmount).AppendLine();
        builder.Append("Restore Rate: ").Append(KitRestoreRate).Append(KitRestoreRate == 1 ? " Point" : " Points").Append(" Per Sec").AppendLine();

        return builder.ToString();
    }
}
