using UnityEngine;

public abstract class RefillableItemData : EquippableItemData
{
    [SerializeField] private Sprite refillIcon = null;


    public Sprite RefillIcon => refillIcon;


    public abstract string GetRefillInfo();
}
