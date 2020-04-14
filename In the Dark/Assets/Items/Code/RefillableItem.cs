using UnityEngine;
using System;

public abstract class RefillableItem : EquippableItem
{
    public event Action<EquippableItem> AmountChangedCallback;


    public abstract void IncreaseAmount();

    public override void OnItemAdded()
    {
        AmountChangedCallback = null;
    }

    protected void InvokeAmountChangedCallback() => AmountChangedCallback?.Invoke(this);
}
