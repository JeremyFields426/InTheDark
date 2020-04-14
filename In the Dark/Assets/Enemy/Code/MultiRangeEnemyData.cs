using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Spinner")]
public class MultiRangeEnemyData : RangeEnemyData
{
    [Header("Additional Attacking Info")]
    [SerializeField] [Min(1)] private int numberOfProjectiles = 3;


    public int NumberOfProjectiles => numberOfProjectiles;
}
