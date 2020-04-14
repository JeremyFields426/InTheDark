using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon/Melee")]
public class MeleeWeaponData : EquippableItemData
{
    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Primary;


    public override string GetInfo()
    {
        throw new System.NotImplementedException();
    }
}
