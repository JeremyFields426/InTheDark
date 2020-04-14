using UnityEngine;

public class State : MonoBehaviour, IHaveState
{
    public bool IsBusy { get; set; } = false;
}
