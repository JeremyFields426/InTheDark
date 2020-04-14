using UnityEngine;
using System;

public interface IHaveFirearmInput : IHaveAngle
{
    event Action ShootCallback;

    event Action ReloadCallback;
}
