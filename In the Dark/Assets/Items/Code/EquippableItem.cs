using UnityEngine;
using System;

public abstract class EquippableItem : MonoBehaviour, IPlaySound
{
    public event Action<Sound> PlaySoundCallback;


    public IHaveState UserState { get; set; }

    public EquippableItemData ItemData { get; set; }


    public abstract void OnItemAdded();

    protected void InvokePlaySoundCallback(Sound s) => PlaySoundCallback?.Invoke(s);
}
