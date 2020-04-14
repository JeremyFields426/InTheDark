using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public event Action<int> EnemyAmountChangedCallback;

    private WeightedList<EnemyData> weightedEnemies;
    private Casket[] allCaskets;
    private int currentEnemyAmount;
    private int currentSpawnAmount;
    private float currentHealthMultiplier;

    [SerializeField] [Min(0)] private int spawnAmount = 5;
    [SerializeField] [Min(0)] private int spawnAmountIncrease = 3;
    [SerializeField] [Min(0)] private float healthMultiplierIncrease = 0.2f;
    [SerializeField] private EnemyData[] enemies = null;


    private void Start()
    {
        currentSpawnAmount = spawnAmount;

        weightedEnemies = new WeightedList<EnemyData>(enemies);

        allCaskets = FindObjectsOfType<Casket>();
        foreach (Casket casket in allCaskets)
        {
            casket.CasketActivatedCallback += SpawnEnemies;
        }
    }

    private void SpawnEnemies(Casket casket)
    {
        Vector3[] spawnLocations = GetSpawnLocations(casket, currentSpawnAmount);

        for (int i = 0; i < currentSpawnAmount; i++)
        {
            EnemyStats enemy = ObjectPooler.Spawn(
                weightedEnemies.GetRandomWeightedItem().Prefab,
                spawnLocations[i],
                Quaternion.identity)
                .GetComponent<EnemyStats>();

            enemy.DeathCallback += () => { currentEnemyAmount--; EnemyAmountChangedCallback?.Invoke(currentEnemyAmount); };
            enemy.InitializeHealth(currentHealthMultiplier);

            currentEnemyAmount++;
        }

        EnemyAmountChangedCallback?.Invoke(currentEnemyAmount);
        currentSpawnAmount += spawnAmountIncrease;
        currentHealthMultiplier += healthMultiplierIncrease;
    }


    private Vector3[] GetSpawnLocations(Casket casket, int amountToBeSpawned)
    {
        Vector3[] spawnLocations = new Vector3[amountToBeSpawned];
        allCaskets.Shuffle();

        int spawnLocationsIndex = 0;
        int allCasketsIndex = 0;
        while (spawnLocationsIndex < spawnLocations.Length)
        {
            Casket currentCasket = allCaskets[allCasketsIndex];

            if (currentCasket != casket)
            {
                spawnLocations[spawnLocationsIndex] = currentCasket.NewSpawnLocation;
                spawnLocationsIndex++;
            }

            allCasketsIndex++;

            if (allCasketsIndex == allCaskets.Length)
            {
                allCasketsIndex = 0;
                allCaskets.Shuffle();
            }
        }

        return spawnLocations;
    }
}
