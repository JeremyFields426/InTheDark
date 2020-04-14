using UnityEngine;

public class SpreadFirearm : Firearm
{
    [SerializeField] private SpreadFirearmData spreadFirearmData = null;


    protected override void Shoot()
    {
        for (int i = 0; i < spreadFirearmData.NumberOfProjectiles; i++)
        {
            float angle = (i - Mathf.Floor(spreadFirearmData.NumberOfProjectiles / 2)) * spreadFirearmData.AngleBetweenProjectiles;
            ObjectPooler.Spawn(
                firearmData.ProjectileData.Prefab, 
                firepoint.position,
                firepoint.transform.rotation * Quaternion.Euler(0f, 0f, angle));
        }

        ObjectPooler.Spawn(firearmData.MuzzleFlashPrefab, firepoint.position, firepoint.rotation, firepoint);

        CurrentMagCapacity--;
        currentFireCooldown = Time.time + firearmData.FireCooldown;
    }
}
