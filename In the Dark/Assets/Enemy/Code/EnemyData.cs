using UnityEngine;

public abstract class EnemyData : ScriptableObject, IHaveWeighting
{
    [Header("Enemy Prefab")]
    [SerializeField] private GameObject prefab = null;
    [SerializeField] [Min(0)] private int weight = 0;

    [Header("Health Info")]
    [SerializeField] private float maxHealth = 100f;

    [Header("Movement Info")]
    [SerializeField] private float speed = 80f;
    [SerializeField] private float stopDistance = 1f;


    public GameObject Prefab => prefab;

    public int Weight => weight;

    public float MaxHealth => maxHealth;

    public float Speed => speed;

    public float StopDistance => stopDistance;
}
