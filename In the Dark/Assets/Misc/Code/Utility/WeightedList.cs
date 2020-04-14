using UnityEngine;
using System.Collections.Generic;

public class WeightedList<T> where T : IHaveWeighting
{
    private List<T> weightedList = new List<T>();
    private int TotalWeight;


    public WeightedList(ICollection<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }

    public WeightedList()
    {

    }

    public void Add(T item)
    {
        TotalWeight += item.Weight;

        weightedList.Add(item);
    }

    public T GetRandomWeightedItem()
    {
        int rand = Random.Range(0, TotalWeight);

        int currentWeight = 0;
        foreach (T item in weightedList)
        {
            if (rand < item.Weight + currentWeight)
            {
                return item;
            }

            currentWeight += item.Weight;
        }

        return default;
    }
}
