using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(EnemySpawner))]
public class WaveController : MonoBehaviour
{
    public event Action<int> OnWaveStart;

    private EnemySpawner enemySpawner;

    private int currentWave;
    private Casket[] allCaskets;
    private List<Casket> currentCaskets = new List<Casket>();
    private List<Casket> previousCaskets = new List<Casket>();

    [SerializeField] private CasketData[] casketTypes = null;


    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.EnemyAmountChangedCallback += EndWave;
    }

    private void Start()
    {
        allCaskets = FindObjectsOfType<Casket>();
        foreach (Casket casket in allCaskets)
        {
            casket.CasketActivatedCallback += StartWave;
        }

        ChooseCaskets();
    }

    private void ChooseCaskets()
    {
        allCaskets.Shuffle();

        int casketCount = 0;
        for (int i = 0; i < allCaskets.Length && casketCount < casketTypes.Length; i++)
        {
            if (!previousCaskets.Contains(allCaskets[i]))
            {
                allCaskets[i].SetActivation(casketTypes[casketCount]);
                currentCaskets.Add(allCaskets[i]);
                casketCount++;
            }
        }
    }

    private void StartWave(Casket casket)
    {
        currentWave++;

        OnWaveStart?.Invoke(currentWave);
    }

    private void EndWave(int amount)
    {
        if (amount != 0) { return; }

        ResetCaskets();
        ChooseCaskets();
    }

    private void ResetCaskets()
    {
        foreach (Casket casket in currentCaskets)
        {
            casket.ResetCasket();
        }

        previousCaskets.Clear();
        previousCaskets.AddRange(currentCaskets);
        currentCaskets.Clear();
    }
}
