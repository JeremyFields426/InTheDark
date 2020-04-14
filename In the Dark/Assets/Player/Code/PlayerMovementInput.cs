using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : MonoBehaviour, IHaveDirection, IHaveAngle, IChangeSpeed
{
    private Camera mainCamera;
    private Controls controls;

    private float speedModifier = 1f;

    [SerializeField] private PlayerData playerData = null;
    [SerializeField] private TargetType targetType = TargetType.Player;


    public TargetType TargetType => targetType;

    public Vector2 Direction { get; private set; }

    public float Angle { get; private set; }


    private void Awake()
    {
        mainCamera = Camera.main;

        controls = new Controls();
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();

    private void Update()
    {
        Direction = controls.Player.Movement.ReadValue<Vector2>() * playerData.Speed * speedModifier * 10f;
        Angle = transform.Angle(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }

    public void ChangeSpeed(float multiplier)
    {
        if (multiplier > 0f)
        {
            speedModifier *= multiplier;
        }
    }
}
