using UnityEngine;

public class ConstantDamage : InflictDamageInRadius
{
    private void Update()
    {
        DamageTargetsInRadius(true);
    }
}
