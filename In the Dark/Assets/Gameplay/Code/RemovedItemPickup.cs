using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class RemovedItemPickup : MonoBehaviour, IGiveInfo, IActivate
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D pickupCollider;

    private ItemController itemController;
    private EquippableItem item;

    [SerializeField] private float activationDistance = 5f;


    public bool CanActivate => itemController != null && itemController.CanAddItem(item.ItemData) && transform.WithinDistanceOf(itemController.transform, activationDistance);


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pickupCollider = GetComponent<BoxCollider2D>();
    }

    public void InitializePickup(ItemController itemController, Sprite icon, EquippableItem item)
    {
        spriteRenderer.sprite = icon;
        pickupCollider.size = icon.bounds.size;
        pickupCollider.offset = icon.bounds.center;

        this.itemController = itemController;
        this.item = item;
    }

    public string GetInfo() => (item != null) ? item.ItemData.GetInfo() : "";

    public void Activate()
    {
        if (itemController != null && itemController.AddItem(item))
        {
            ObjectPooler.Despawn(gameObject);
        }
    }
}
