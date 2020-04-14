using UnityEngine;

[System.Serializable]
public class SpawnablePickup
{
    [SerializeField] private EquippableItemData itemData = null;

    [SerializeField] private bool isRefill = false;


    public EquippableItemData ItemData => itemData;

    public bool IsRefill => isRefill;
}
