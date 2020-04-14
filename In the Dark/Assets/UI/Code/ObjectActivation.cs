using UnityEngine;
using System.Collections;

public class ObjectActivation : MonoBehaviour
{
    private Camera mainCamera;
    private Controls controls;

    private GameObject currentTarget;
    private IActivate currentTargetActivator;

    [SerializeField] private State playerState = null;

    [Header("Object Activation")]
    [SerializeField] private Transform canActivateCursor = null;
    [SerializeField] private Transform cannotActivateCursor = null;


    private void Awake()
    {
        mainCamera = Camera.main;

        controls = new Controls();
        controls.Player.Activate.performed += (ctx) => { Activate(); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();

    private void Start()
    {
        ResetActivation();
    }

    private void Update()
    {
        CheckUnderCursor();

        canActivateCursor.SetPositionOnMouse(mainCamera, Vector3.zero);
        cannotActivateCursor.SetPositionOnMouse(mainCamera, Vector3.zero);
    }

    private void CheckUnderCursor()
    {
        GameObject target = mainCamera.GetGameObjectUnderMouse();

        if (playerState.IsBusy || target == null)
        {
            ResetActivation();
            return;
        }

        if (target.gameObject != currentTarget && target.TryGetComponent(out currentTargetActivator))
        {
            currentTarget = target.gameObject;

            StopAllCoroutines();
            StartCoroutine(ChangeCursor());
        }
    }

    private IEnumerator ChangeCursor()
    {
        Cursor.visible = false;

        while (currentTarget != null && currentTargetActivator != null)
        {
            if (currentTargetActivator.CanActivate)
            {
                canActivateCursor.gameObject.SetActive(true);
                cannotActivateCursor.gameObject.SetActive(false);
            }
            else
            {
                canActivateCursor.gameObject.SetActive(false);
                cannotActivateCursor.gameObject.SetActive(true);
            }

            yield return null;
        }
    }

    private void Activate()
    {
        if (currentTarget != null)
        {
            currentTargetActivator.Activate();
        }
    }

    private void ResetActivation()
    {
        currentTarget = null;
        currentTargetActivator = null;

        Cursor.visible = true;
        canActivateCursor.gameObject.SetActive(false);
        cannotActivateCursor.gameObject.SetActive(false);
    }
}
