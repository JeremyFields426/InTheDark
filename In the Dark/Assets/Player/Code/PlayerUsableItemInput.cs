using UnityEngine;
using System;

public class PlayerUsableItemInput : MonoBehaviour, IHaveUsableItemInput
{
    public event Action UseCallback;

    private Controls controls;


    private void Awake()
    {
        controls = new Controls();
        controls.Player.SecondaryItem.performed += (ctx) => { UseCallback?.Invoke(); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();
}
