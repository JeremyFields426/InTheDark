using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IHaveFirearmInput))]
public class Firearm : RefillableItem
{
    protected float currentFireCooldown;

    [SerializeField] protected Transform firepoint = null;
    [SerializeField] protected FirearmData firearmData = null;


    public int CurrentAmmo { get; protected set; }

    public int CurrentMagCapacity { get; protected set; }


    private void Awake()
    {
        IHaveFirearmInput firearmInput = GetComponent<IHaveFirearmInput>();
        firearmInput.ShootCallback += CheckShoot;
        firearmInput.ReloadCallback += () => { StartCoroutine(CheckReload()); };

        CurrentAmmo = firearmData.StartingAmmo;
        CurrentMagCapacity = firearmData.MaxMagCapacity;
    }

    protected virtual void CheckShoot()
    {
        if (UserState.IsBusy) { return; }

        if (Time.time > currentFireCooldown)
        {
            if (CurrentMagCapacity > 0)
            {
                Shoot();
                InvokeAmountChangedCallback();
                InvokePlaySoundCallback(firearmData.ShootSound);
            }
        }
    }

    protected virtual void Shoot()
    {
        ObjectPooler.Spawn(firearmData.ProjectileData.Prefab, firepoint.position, firepoint.rotation);
        ObjectPooler.Spawn(firearmData.MuzzleFlashPrefab, firepoint.position, firepoint.rotation, firepoint);

        CurrentMagCapacity--;
        currentFireCooldown = Time.time + firearmData.FireCooldown;
    }

    protected virtual IEnumerator CheckReload()
    {
        if (UserState.IsBusy) { yield break; }

        if (CurrentAmmo > 0 && CurrentMagCapacity < firearmData.MaxMagCapacity)
        {
            InvokePlaySoundCallback(firearmData.ReloadSound);
            UserState.IsBusy = true;

            yield return new WaitForSeconds(1); // TODO: Add wait time to reloading 

            Reload();
            InvokeAmountChangedCallback();
        }
    }

    protected virtual void Reload()
    {
        int difference = firearmData.MaxMagCapacity - CurrentMagCapacity;

        if (CurrentAmmo < difference)
        {
            CurrentMagCapacity += CurrentAmmo;
            CurrentAmmo = 0;
        }
        else
        {
            CurrentAmmo -= difference;
            CurrentMagCapacity += difference;
        }

        UserState.IsBusy = false;
    }

    public override void IncreaseAmount()
    {
        CurrentAmmo += firearmData.MaxMagCapacity;

        if (gameObject.activeSelf)
        {
            InvokeAmountChangedCallback();
        }
    }
}
