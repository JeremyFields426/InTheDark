using UnityEngine;
using System;

public class PlayASound : MonoBehaviour, IPlaySound
{
    public event Action<Sound> PlaySoundCallback;

    [SerializeField] private Sound sound = null;


    // TODO: Events can only reference one of these at a time.
    public void PlaySound()
    {
        PlaySoundCallback?.Invoke(sound);
    }
}
