using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class CreatedItemPickup : MonoBehaviour, IGiveInfo, IActivate
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D pickupCollider;

    private ItemController itemController;
    private EquippableItemData itemData;

    [SerializeField] private float activationDistance = 5f;


    public bool CanActivate => itemController != null && itemController.CanAddItem(itemData) && transform.WithinDistanceOf(itemController.transform, activationDistance);


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pickupCollider = GetComponent<BoxCollider2D>();
    }

    public void InitializePickup(ItemController itemController, Sprite icon, EquippableItemData itemData)
    {
        spriteRenderer.sprite = icon;
        pickupCollider.size = icon.bounds.size;
        pickupCollider.offset = icon.bounds.center;

        this.itemController = itemController;
        this.itemData = itemData;
    }

    public string GetInfo() => (itemData != null) ? itemData.GetInfo() : "";

    public void Activate()
    {
        if (itemController != null && itemController.AddItem(itemData))
        {
            ObjectPooler.Despawn(gameObject);
        }
    }
}
