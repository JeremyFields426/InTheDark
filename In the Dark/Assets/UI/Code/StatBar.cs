using UnityEngine;

[RequireComponent(typeof(IHaveStat))]
public class StatBar : MonoBehaviour
{
    private float startingScaleOfX;

    [SerializeField] private GameObject statBar = null;
    [SerializeField] private StatType statType = StatType.Health;


    private void Awake()
    {
        GetComponent<IHaveStat>().RegisterStatChangedCallback(statType, OnStatChanged);

        startingScaleOfX = statBar.transform.localScale.x;
    }

    private void OnStatChanged(float statPercentage)
    {
        statBar.transform.localScale = new Vector3(startingScaleOfX * statPercentage, statBar.transform.localScale.y, 1f);
    }
}
