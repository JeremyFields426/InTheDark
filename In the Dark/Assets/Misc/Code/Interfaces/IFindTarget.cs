using UnityEngine;

public interface IFindTarget
{
    Transform Target { get; }

    void FindTarget();
}
