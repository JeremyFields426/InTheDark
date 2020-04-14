using UnityEngine;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentMagCapacityText = null;
    [SerializeField] private TextMeshProUGUI currentAmmoText = null;

    [SerializeField] private TextMeshProUGUI currentSecondaryAmountText = null;

    [SerializeField] private TextMeshProUGUI currentWaveText = null;
    [SerializeField] private TextMeshProUGUI enemyAmountText = null;


    private void Awake()
    {
        ItemController itemController = FindObjectOfType<ItemController>();
        itemController.ItemAddedCallback += OnItemAdded;
        itemController.PrimarySwitchedCallback += UpdatePrimary;
        itemController.SecondarySwitchedCallback += UpdateSecondary;

        FindObjectOfType<WaveController>().OnWaveStart += OnWaveChanged;
        FindObjectOfType<EnemySpawner>().EnemyAmountChangedCallback += OnEnemyAmountChanged;
    }

    private void OnItemAdded(EquippableItem item)
    {
        if (item is RefillableItem refillableItem)
        {
            refillableItem.AmountChangedCallback += OnItemChanged;
        }
    }

    private void OnItemChanged(EquippableItem item)
    {
        switch (item.ItemData.EquipmentSlot)
        {
            case EquipmentSlot.Primary:
                UpdatePrimary(item);
                break;
            case EquipmentSlot.Secondary:
            default:
                UpdateSecondary(item);
                break;
        }
    }

    private void UpdatePrimary(EquippableItem item)
    {
        if (item is Firearm firearm)
        {
            UpdatePrimary(firearm.CurrentMagCapacity, firearm.CurrentAmmo);
        }
        else
        {
            currentMagCapacityText.gameObject.SetActive(false);
            currentAmmoText.gameObject.SetActive(false);
        }
    }

    private void UpdatePrimary(int currentMagCapacity, int currentAmmo)
    {
        currentMagCapacityText.gameObject.SetActive(true);
        currentAmmoText.gameObject.SetActive(true);

        currentMagCapacityText.text = currentMagCapacity.ToString("00");
        currentAmmoText.text = currentAmmo.ToString("000");
    }

    private void UpdateSecondary(EquippableItem item)
    {
        if (item is Throwable throwable)
        {
            UpdateSecondary(throwable.CurrentThrowableAmount);
        }
        else if (item is Kit kit)
        {
            UpdateSecondary(kit.CurrentKitAmount);
        }
        else
        {
            currentSecondaryAmountText.gameObject.SetActive(false);
        }
    }

    private void UpdateSecondary(int amount)
    {
        currentSecondaryAmountText.gameObject.SetActive(true);

        currentSecondaryAmountText.text = amount.ToString("00");
    }

    private void OnWaveChanged(int wave)
    {
        currentWaveText.text = $"Wave {wave}";
    }

    private void OnEnemyAmountChanged(int amount)
    {
        enemyAmountText.text = $"{amount} {((amount == 1) ? "Spirit" : "Spirits")} Left";
    }
}
