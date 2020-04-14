using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour, IFindTarget
{
    public Transform Target { get; private set; }


    private void OnEnable()
    {
        Target = null;
    }

    public void FindTarget()
    {
        Target = GameObject.Find("Player")?.transform;
    }
}
