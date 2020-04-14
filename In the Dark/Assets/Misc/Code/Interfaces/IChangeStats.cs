using UnityEngine;
using System;

public interface IChangeStats
{
    void ChangeCurrentStat(StatType statType, float amount);
    float GetCurrentStat(StatType statType);
    float GetMaxStat(StatType statType);
}
