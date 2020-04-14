using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IHaveUsableItemInput))]
public class Kit : RefillableItem
{
    private IChangeStats kitUser;
    private bool IsHealing;

    [SerializeField] private KitData kitData = null;


    public KitData KitData => kitData;

    public int CurrentKitAmount { get; private set; }


    private void Awake()
    {
        GetComponent<IHaveUsableItemInput>().UseCallback += CheckHealing;

        kitUser = transform.parent.GetComponent<IChangeStats>();

        CurrentKitAmount = KitData.StartingAmount;
    }

    private void OnDisable()
    {
        IsHealing = false;
        StopAllCoroutines();
    }

    private void CheckHealing()
    {
        if (IsHealing || CurrentKitAmount == 0 || Mathf.Approximately(kitUser.GetCurrentStat(KitData.StatType), kitUser.GetMaxStat(KitData.StatType))) { return; }

        StartCoroutine(StartHealing());
    }

    private IEnumerator StartHealing()
    {
        IsHealing = true;
        CurrentKitAmount--;
        InvokeAmountChangedCallback();

        float amountRestored = 0f;
        while (amountRestored < KitData.KitRestoreAmount && !Mathf.Approximately(kitUser.GetCurrentStat(KitData.StatType), kitUser.GetMaxStat(KitData.StatType)))
        {
            kitUser.ChangeCurrentStat(KitData.StatType, KitData.KitRestoreRate * Time.deltaTime);
            amountRestored += KitData.KitRestoreRate * Time.deltaTime;

            if (kitUser.GetCurrentStat(KitData.StatType) >= kitUser.GetMaxStat(KitData.StatType))
            {
                kitUser.ChangeCurrentStat(KitData.StatType, kitUser.GetMaxStat(KitData.StatType) - kitUser.GetCurrentStat(KitData.StatType));
            }

            yield return null;
        }
        
        IsHealing = false;
    }

    public override void IncreaseAmount()
    {
        CurrentKitAmount++;

        if (gameObject.activeSelf)
        {
            InvokeAmountChangedCallback();
        }
    }
}
