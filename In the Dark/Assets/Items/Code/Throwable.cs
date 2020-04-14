using UnityEngine;

[RequireComponent(typeof(IHaveThrowableInput))]
public class Throwable : RefillableItem
{
    protected float currentThrowCooldown;

    [SerializeField] protected ThrowableData throwableData = null;


    public int CurrentThrowableAmount { get; protected set; }


    private void Awake()
    {
        GetComponent<IHaveThrowableInput>().ThrowCallback += CheckThrow;

        CurrentThrowableAmount = throwableData.StartingAmount;
    }

    protected virtual void CheckThrow()
    {
        if (UserState.IsBusy) { return; }

        if (Time.time > currentThrowCooldown && CurrentThrowableAmount > 0)
        {
            Throw();
            InvokePlaySoundCallback(throwableData.ThrowSound);
        }
    }

    protected virtual void Throw()
    {
        ObjectPooler.Spawn(throwableData.ProjectileData.Prefab, transform.position, transform.rotation);

        CurrentThrowableAmount--;
        currentThrowCooldown = Time.time + throwableData.ThrowCooldown;
    }

    public override void IncreaseAmount()
    {
        CurrentThrowableAmount++;

        if (gameObject.activeSelf)
        {
            InvokeAmountChangedCallback();
        }
    }
}
