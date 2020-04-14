using UnityEngine;
using System;

public interface IAmMenu
{
    bool IsOpen { get; }

    bool StacksWithOtherMenus { get; }

    event Action<IAmMenu> RequestToggleCallback;

    void Toggle(bool toggle);
}
