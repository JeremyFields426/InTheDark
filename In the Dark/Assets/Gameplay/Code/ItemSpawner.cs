using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemController itemController = null;
    [SerializeField] private RefillPickup refillPickupPrefab = null;
    [SerializeField] private CreatedItemPickup itemPickupPrefab = null;


    private void Start()
    {
        foreach (Casket casket in FindObjectsOfType<Casket>())
        {
            casket.CasketActivatedCallback += SpawnItem;
        }
    }

    private void SpawnItem(Casket casket)
    {
        SpawnablePickup pickup = GetPickup(casket);

        if (pickup == null) { return; }

        if (pickup.IsRefill)
        {
            RefillableItemData refillableItemData = (RefillableItemData)pickup.ItemData;

            if (refillableItemData == null) { return; }

            ObjectPooler.Spawn(refillPickupPrefab.gameObject, casket.NewSpawnLocation, Quaternion.identity)
                .GetComponent<RefillPickup>()
                .InitializePickup(itemController, refillableItemData.RefillIcon, refillableItemData);
        }
        else
        {
            ObjectPooler.Spawn(itemPickupPrefab.gameObject, casket.NewSpawnLocation, Quaternion.identity)
                .GetComponent<CreatedItemPickup>()
                .InitializePickup(itemController, pickup.ItemData.ItemIcon, pickup.ItemData);
        }
    }

    private SpawnablePickup GetPickup(Casket casket)
    {
        // TODO: Make pickups have weighting
        SpawnablePickup[] currentPickups = casket.CasketData.SpawnablePickupsClone;
        currentPickups.Shuffle();

        for (int i = 0; i < currentPickups.Length; i++)
        {
            if (itemController.CanAddItem(currentPickups[i].ItemData) ^ currentPickups[i].IsRefill)
            {
                return currentPickups[i];
            }
        }

        return null;
    }
}