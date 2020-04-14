using UnityEngine;
using UnityEngine.InputSystem; // TODO: Remove this later
using System.Collections;

public class ChargeFirearm : Firearm
{
    protected override void CheckShoot()
    {
        if (UserState.IsBusy) { return; }

        if (Time.time > currentFireCooldown)
        {
            if (CurrentMagCapacity > 0)
            {
                UserState.IsBusy = true;
                Shoot();
            }
        }
    }

    protected override void Shoot()
    {
        StartCoroutine(StartCharging(ObjectPooler.Spawn(firearmData.ProjectileData.Prefab, firepoint.position, firepoint.rotation).transform));
    }

    private IEnumerator StartCharging(Transform projectile)
    {
        // TODO: Change behaviour of "Charge" Rifle
        while (Mouse.current.leftButton.isPressed) 
        {
            projectile.position = firepoint.position;
            projectile.rotation = firepoint.rotation;

            yield return null; 
        }

        CurrentMagCapacity--;
        UserState.IsBusy = false;
        currentFireCooldown = Time.time + firearmData.FireCooldown;
        InvokeAmountChangedCallback();
    }
}
