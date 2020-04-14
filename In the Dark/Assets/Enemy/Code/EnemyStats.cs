using UnityEngine;
using System;

public class EnemyStats : MonoBehaviour, IHaveStat
{
    public event Action<float> HealthChangedCallback;
    public event Action DeathCallback;

    private float amountChanged;
    private float currentHealth;
    private float currentMaxHealth;

    [SerializeField] private EnemyData baseEnemyData = null;
    [SerializeField] private TargetType targetType = TargetType.Enemy;

    [SerializeField] private float woundEffectThreshold = 30f;
    [SerializeField] private GameObject woundEffect = null;
    [SerializeField] private GameObject deathEffect = null;


    public TargetType TargetType => targetType;


    private void OnDisable()
    {
        DeathCallback = null;
    }

    public void RegisterStatChangedCallback(StatType statType, Action<float> OnStatChanged)
    {
        HealthChangedCallback += OnStatChanged;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        amountChanged += amount;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Die();
        }
        else if (amountChanged >= woundEffectThreshold)
        {
            amountChanged = 0f;
            ObjectPooler.Spawn(woundEffect, transform.position, woundEffect.transform.rotation);
        }

        InvokeHealthChangedCallback();
    }

    public void InitializeHealth(float maxHealthMultiplier)
    {
        if (maxHealthMultiplier >= 0f)
        {
            currentMaxHealth = baseEnemyData.MaxHealth + (maxHealthMultiplier * baseEnemyData.MaxHealth);
        }

        currentHealth = currentMaxHealth;
        InvokeHealthChangedCallback();
    }

    private void Die()
    {
        DeathCallback?.Invoke();

        ObjectPooler.Spawn(deathEffect, transform.position, deathEffect.transform.rotation);

        ObjectPooler.Despawn(gameObject);
    }

    private void InvokeHealthChangedCallback() => HealthChangedCallback?.Invoke(currentHealth / currentMaxHealth);
}
