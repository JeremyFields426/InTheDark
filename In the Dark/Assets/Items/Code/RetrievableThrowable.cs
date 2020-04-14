using UnityEngine;
using System.Collections;

public class RetrievableThrowable : Throwable
{
    [SerializeField] private RetrievableThrowableData retrievableThrowableData = null;


    protected override void Throw()
    {
        CurrentThrowableAmount--;
        currentThrowCooldown = Time.time + throwableData.ThrowCooldown;

        StartCoroutine(CheckRetrieve(ObjectPooler.Spawn(throwableData.ProjectileData.Prefab, transform.position, transform.rotation).transform));
    }

    private IEnumerator CheckRetrieve(Transform currentThrowable)
    {
        float currentRetrieveCooldown = Time.time + retrievableThrowableData.RetrieveCooldown;
        float currentRetrieveTimeout = Time.time + retrievableThrowableData.RetrieveTimeout;
        
        while (true)
        {
            if (Time.time > currentRetrieveTimeout)
            {
                break;
            }

            if (Time.time > currentRetrieveCooldown && transform.WithinDistanceOf(currentThrowable.position, retrievableThrowableData.RetrieveDistance))
            {
                CurrentThrowableAmount++;
                InvokePlaySoundCallback(retrievableThrowableData.ThrowSound); // TODO: Add Sound for picking up
                break;
            }

            yield return null;
        }

        ObjectPooler.Despawn(currentThrowable.gameObject);
    }
}
