using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName = "Item/Lantern")]
public class LanternData : EquippableItemData
{
    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Secondary;


    public override string GetInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(Title).AppendLine();
        builder.Append("Description: ").Append(Description).AppendLine();

        return builder.ToString();
    }
}
