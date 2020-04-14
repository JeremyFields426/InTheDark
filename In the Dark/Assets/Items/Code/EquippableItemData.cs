using UnityEngine;

public abstract class EquippableItemData : ScriptableObject, IGiveInfo
{
    [Header("General Info")]
    [SerializeField] private string title = "New Equippable Item";
    [SerializeField] [Multiline] private string description = "Equippable Description";
    [SerializeField] private Sprite itemIcon = null;

    [Header("Item Prefab")]
    [SerializeField] private GameObject prefab = null;


    public string Title => title;

    public string Description => description;

    public Sprite ItemIcon => itemIcon;

    public GameObject Prefab => prefab;

    public abstract EquipmentSlot EquipmentSlot { get; }


    public EquippableItem MakeItem(Transform parent, IHaveState userState)
    {
        EquippableItem item = ObjectPooler.Create(Prefab, parent).GetComponent<EquippableItem>();
        item.UserState = userState;
        item.ItemData = this;
        item.gameObject.SetActive(false);

        return item;
    }

    public abstract string GetInfo();
}
