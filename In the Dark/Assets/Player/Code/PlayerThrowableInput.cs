using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerThrowableInput : MonoBehaviour, IHaveThrowableInput
{
    public event Action ThrowCallback;

    private Camera mainCamera;
    private Controls controls;

    public float Angle { get; private set; }
    

    private void Awake()
    {
        mainCamera = Camera.main;

        controls = new Controls();
        controls.Player.SecondaryItem.performed += (ctx) => { ThrowCallback?.Invoke(); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();

    private void Update()
    {
        Angle = transform.Angle(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }
}
