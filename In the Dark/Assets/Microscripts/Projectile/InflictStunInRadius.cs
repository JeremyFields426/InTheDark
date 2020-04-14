using UnityEngine;
using System.Collections.Generic;

public class InflictStunInRadius : MonoBehaviour
{
    private HashSet<IChangeSpeed> currentTargets;
    private HashSet<IChangeSpeed> acquiredTargets;
    private HashSet<IChangeSpeed> lostTargets;

    [SerializeField] private StunProjectileData stunProjectileData = null;


    private void OnEnable()
    {
        currentTargets = new HashSet<IChangeSpeed>();
        acquiredTargets = new HashSet<IChangeSpeed>();
        lostTargets = new HashSet<IChangeSpeed>();
    }

    private void OnDisable()
    {
        ResetLostTargets();
    }

    public void StunTargetsInRadius()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, stunProjectileData.AreaOfEffectRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out IChangeSpeed target) && stunProjectileData.TargetTypes.Contains(target.TargetType))
            {
                acquiredTargets.Add(target);

                if (!currentTargets.Contains(target))
                {
                    target.ChangeSpeed(stunProjectileData.StunPercentage);
                    currentTargets.Add(target);
                }
            }
        }
        
        ResetLostTargets();
    }

    private void ResetLostTargets()
    {
        lostTargets.Clear();
        lostTargets.UnionWith(currentTargets);
        lostTargets.ExceptWith(acquiredTargets);

        foreach (IChangeSpeed target in lostTargets)
        {
            target.ChangeSpeed(1 / stunProjectileData.StunPercentage);
            currentTargets.Remove(target);
        }

        acquiredTargets.Clear();
    }
}
