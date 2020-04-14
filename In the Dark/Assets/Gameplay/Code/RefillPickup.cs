using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class RefillPickup : MonoBehaviour, IGiveInfo, IActivate
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D pickupCollider;

    private ItemController itemController;
    private RefillableItemData itemData;

    [SerializeField] private float activationDistance = 5f;


    public bool CanActivate => GetRefillableItem() != null && transform.WithinDistanceOf(itemController.transform, activationDistance);


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pickupCollider = GetComponent<BoxCollider2D>();
    }

    public void InitializePickup(ItemController itemController, Sprite icon, RefillableItemData itemData)
    {
        spriteRenderer.sprite = icon;
        pickupCollider.size = icon.bounds.size;
        pickupCollider.offset = icon.bounds.center;

        this.itemController = itemController;
        this.itemData = itemData;
    }

    public string GetInfo() => (itemData != null) ? itemData.GetRefillInfo() : "";

    private RefillableItem GetRefillableItem()
    {
        if (itemController != null)
        {
            return itemController.GetItem(itemData) as RefillableItem;
        }

        return null;
    }

    public void Activate()
    {
        GetRefillableItem().IncreaseAmount();

        ObjectPooler.Despawn(gameObject); 
    }
}
