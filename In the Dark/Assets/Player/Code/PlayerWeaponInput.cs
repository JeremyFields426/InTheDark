using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerWeaponInput : MonoBehaviour, IHaveFirearmInput
{
    public event Action ShootCallback;
    public event Action ReloadCallback;

    private Camera mainCamera;
    private Controls controls;


    public float Angle { get; private set; }


    private void Awake()
    {
        mainCamera = Camera.main;

        controls = new Controls();
        controls.Player.PrimaryItem.performed += (ctx) => { ShootCallback?.Invoke(); };
        controls.Player.Reload.performed += (ctx) => { ReloadCallback?.Invoke(); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();

    private void Update()
    {
        Angle = transform.Angle(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }
}
