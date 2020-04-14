using UnityEngine;

public interface IActivate
{
    void Activate();

    bool CanActivate { get; }
}
