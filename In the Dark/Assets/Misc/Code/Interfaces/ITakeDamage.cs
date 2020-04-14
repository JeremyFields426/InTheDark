using UnityEngine;

public interface ITakeDamage : IAmTarget
{
    void TakeDamage(float amount);
}
