using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Stun")]
public class StunProjectileData : AOEProjectileData
{
    [Header("Stunning Info")]
    [SerializeField] [Range(0f, 1f)] private float stunPercentage = 3f;


    public float StunPercentage => stunPercentage;
}
