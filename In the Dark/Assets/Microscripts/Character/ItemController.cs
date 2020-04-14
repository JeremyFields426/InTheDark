using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(IHaveState))]
public class ItemController : MonoBehaviour
{
    public event Action<EquippableItem> ItemAddedCallback;
    public event Action<EquippableItem> PrimarySwitchedCallback;
    public event Action<EquippableItem> SecondarySwitchedCallback;

    private List<EquippableItem> allItems = new List<EquippableItem>();

    [SerializeField] private RemovedItemPickup itemPickupPrefab = null;
    [SerializeField] private EquippableItemData[] startingItems = null;


    public EquippableItem CurrentPrimary { get; private set; }

    public EquippableItem CurrentSecondary { get; private set; }


    private void Start()
    {
        AddDefaultItems();
    }

    private void AddDefaultItems()
    {
        foreach (EquippableItemData item in startingItems)
        {
            AddItem(item);
        }
    }

    public bool CanAddItem(EquippableItemData itemData)
    {
        if (itemData == null) { return false; }

        foreach (EquippableItem item in allItems)
        {
            if (item.ItemData == itemData)
            {
                return false;
            }
        }

        return true;
    }

    public bool AddItem(EquippableItemData itemData)
    {
        if (!CanAddItem(itemData)) { return false; }

        allItems.Add(itemData.MakeItem(transform, GetComponent<IHaveState>()));
        ItemAddedCallback?.Invoke(allItems[allItems.Count - 1]);
        return true;
    }

    public bool AddItem(EquippableItem item)
    {
        if (!CanAddItem(item.ItemData)) { return false; }

        allItems.Add(item);
        item.OnItemAdded();
        ItemAddedCallback?.Invoke(allItems[allItems.Count - 1]);
        return true;
    }

    public bool RemoveItem(EquippableItem item)
    {
        if (!allItems.Contains(item)) { return false; }

        if (CurrentPrimary == item || CurrentSecondary == item)
        {
            SwitchItem(item);
        }

        ObjectPooler.Spawn(itemPickupPrefab.gameObject, transform.position, Quaternion.identity)
            .GetComponent<RemovedItemPickup>()
            .InitializePickup(this, item.ItemData.ItemIcon, item);

        allItems.Remove(item);

        return true;
    }

    public EquippableItem GetItem(EquippableItemData itemData)
    {
        foreach (EquippableItem item in allItems)
        {
            if (item.ItemData == itemData)
            {
                return item;
            }
        }

        return null;
    }

    public void SwitchItem(EquippableItem item)
    {
        if (!allItems.Contains(item)) { return; }

        switch (item.ItemData.EquipmentSlot)
        {
            case EquipmentSlot.Primary:
                CurrentPrimary = (CurrentPrimary != item) ? item : null;
                PrimarySwitchedCallback?.Invoke(CurrentPrimary);
                ToggleWeapons(CurrentPrimary, EquipmentSlot.Primary);
                break;
            case EquipmentSlot.Secondary:
                CurrentSecondary = (CurrentSecondary != item) ? item : null;
                SecondarySwitchedCallback?.Invoke(CurrentSecondary);
                ToggleWeapons(CurrentSecondary, EquipmentSlot.Secondary);
                break;
        }
    }

    private void ToggleWeapons(EquippableItem currentItem, EquipmentSlot equipmentSlot)
    {
        foreach (EquippableItem item in allItems)
        {
            if (item.ItemData.EquipmentSlot == equipmentSlot)
            {
                item.gameObject.SetActive(currentItem == item);
            }
        }
    }
}
