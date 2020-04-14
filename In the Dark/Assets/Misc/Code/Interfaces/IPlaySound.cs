using UnityEngine;
using System;

public interface IPlaySound
{
    event Action<Sound> PlaySoundCallback;
}
