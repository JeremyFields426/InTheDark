using UnityEngine;
using System;

public interface IHaveStat : ITakeDamage
{
    void RegisterStatChangedCallback(StatType statType, Action<float> OnStatChanged);
}
