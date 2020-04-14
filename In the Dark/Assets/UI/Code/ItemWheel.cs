using UnityEngine;
using System;

public class ItemWheel : CircularMenu, IAmMenu
{
    public event Action<IAmMenu> RequestToggleCallback;

    private Controls controls;

    [SerializeField] private ItemController itemController = null;
    [SerializeField] private bool stacksWithOtherMenus = false;


    public bool IsOpen { get; private set; }

    public bool StacksWithOtherMenus => stacksWithOtherMenus;


    protected void Awake()
    {
        itemController.ItemAddedCallback += AddItem;

        controls = new Controls();
        controls.Player.ItemMenu.performed += (ctx) => { RequestToggleCallback?.Invoke(this); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();

    public void Toggle(bool toggle)
    {
        menu.gameObject.SetActive(toggle);

        IsOpen = toggle;
    }

    private void AddItem(EquippableItem item)
    {
        AddPiece(item.ItemData.ItemIcon, () => { itemController.SwitchItem(item); }, () => { itemController.RemoveItem(item); });
    }
}
