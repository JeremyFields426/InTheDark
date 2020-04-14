using UnityEngine;
using System;

[RequireComponent(typeof(ItemController))]
public class PlayerStats : MonoBehaviour, IHaveStat, IChangeStats
{
    public event Action<float> HealthChangedCallback;
    public event Action<float> ArmorChangedCallback;

    private float amountChanged;
    private float currentHealth;
    private float currentArmor;

    [Header("Player Data")]
    [SerializeField] private PlayerData playerData = null;
    [SerializeField] private TargetType targetType = TargetType.Player;

    [Header("Effects")]
    [SerializeField] private float woundEffectThreshold = 30f;
    [SerializeField] private GameObject woundEffect = null;
    [SerializeField] private GameObject deathEffect = null;


    public TargetType TargetType => targetType;


    private void Start()
    {
        SetStats();
    }

    private void SetStats()
    {
        currentHealth = playerData.StartingHealth;
        currentArmor = playerData.StartingArmor;

        InvokeHealthChangedCallback();
        InvokeArmorChangedCallback();
    }

    public void RegisterStatChangedCallback(StatType statType, Action<float> OnStatChanged)
    {
        switch (statType)
        {
            case StatType.Armor:
                ArmorChangedCallback += OnStatChanged;
                break;
            case StatType.Health:
            default:
                HealthChangedCallback += OnStatChanged;
                break;
        }
    }

    public void ChangeCurrentStat(StatType statType, float amount)
    {
        switch (statType)
        {
            case StatType.Armor:
                currentArmor += amount;
                InvokeArmorChangedCallback();
                break;
            case StatType.Health:
            default:
                currentHealth += amount;
                InvokeHealthChangedCallback();
                break;
        }
    }

    public float GetCurrentStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Armor:
                return currentArmor;
            case StatType.Health:
            default:
                return currentHealth;
        }
    }

    public float GetMaxStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.Armor:
                return playerData.MaxArmor;
            case StatType.Health:
            default:
                return playerData.MaxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        amount = Mathf.Abs(amount);
        amountChanged += amount;
        float difference = currentArmor - amount;

        if (difference <= 0f)
        {
            currentArmor = 0f;
            currentHealth += difference;
        }
        else
        {
            currentArmor = difference;
        }

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Die();
        }
        else if (amountChanged >= woundEffectThreshold)
        {
            ObjectPooler.Spawn(woundEffect, transform.position, woundEffect.transform.rotation);
            amountChanged = 0f;
        }

        InvokeHealthChangedCallback();
        InvokeArmorChangedCallback();
    }

    private void Die()
    {
        ObjectPooler.Spawn(deathEffect, transform.position, deathEffect.transform.rotation);
        gameObject.SetActive(false);
    }

    private void InvokeHealthChangedCallback() => HealthChangedCallback?.Invoke(currentHealth / playerData.MaxHealth);

    private void InvokeArmorChangedCallback() => ArmorChangedCallback?.Invoke(currentArmor / playerData.MaxArmor);
}
