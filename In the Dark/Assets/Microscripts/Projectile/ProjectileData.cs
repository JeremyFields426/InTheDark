using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Projectile/Standard")]
public class ProjectileData : ScriptableObject
{
    [Header("Projectile Prefab")]
    [SerializeField] private GameObject prefab = null;

    [Header("Movement Info")]
    [SerializeField] private float speed = 30f;
    [SerializeField] private float maxTravelDistance = 30f;

    [Header("Damaging Info")]
    [SerializeField] private float damage = 100f;
    [SerializeField] private List<TargetType> targetTypes = new List<TargetType>();


    public GameObject Prefab => prefab;

    public float Damage => damage;

    public float Speed => speed;

    public float MaxTravelDistance => maxTravelDistance;

    public List<TargetType> TargetTypes => targetTypes;
}
