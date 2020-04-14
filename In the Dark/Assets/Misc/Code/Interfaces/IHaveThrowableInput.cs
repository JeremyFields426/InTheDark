using UnityEngine;
using System;

public interface IHaveThrowableInput : IHaveAngle
{
    event Action ThrowCallback;
}
