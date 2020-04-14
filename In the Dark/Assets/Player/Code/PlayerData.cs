using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Player")]
public sealed class PlayerData : ScriptableObject
{
    [SerializeField] [Min(0f)] private float speed = 60f;

    [SerializeField] [Min(1f)] private float maxHealth = 100f;
    [SerializeField] [Min(1f)] private float startingHealth = 100f;
    [SerializeField] [Min(1f)] private float maxArmor = 100f;
    [SerializeField] [Min(1f)] private float startingArmor = 50f;


    public float Speed => speed;

    public float MaxHealth => maxHealth;

    public float StartingHealth => startingHealth;

    public float MaxArmor => maxArmor;

    public float StartingArmor => startingArmor;
}
