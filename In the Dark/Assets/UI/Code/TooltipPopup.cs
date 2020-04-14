using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TooltipPopup : MonoBehaviour
{
    private Camera mainCamera;

    private GameObject currentTarget;

    [SerializeField] private State playerState = null;

    [Header("Tooltip Popup")]
    [SerializeField] private Mask popupMask = null;
    [SerializeField] private TextMeshProUGUI tooltipText = null;
    [SerializeField] private int popupFrameBuffer = 5;
    [SerializeField] private Vector3 popupOffset = new Vector3(0f, 0.75f, 0f);


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        HideInfo();
    }

    private void Update()
    {
        CheckUnderCursor();

        popupMask.transform.SetPositionOnMouse(mainCamera, popupOffset);
    }

    private void CheckUnderCursor()
    {
        GameObject target = mainCamera.GetGameObjectUnderMouse();

        if (playerState.IsBusy || target == null)
        {
            currentTarget = null;
            HideInfo();

            return;
        }

        if (target != currentTarget && target.TryGetComponent(out IGiveInfo targetInfo))
        {
            currentTarget = target;
            StopAllCoroutines();
            StartCoroutine(DisplayInfo(targetInfo));
        }
    }

    private IEnumerator DisplayInfo(IGiveInfo targetInfo)
    {
        popupMask.enabled = true;
        tooltipText.text = targetInfo.GetInfo();

        int count = 0;
        while (count < popupFrameBuffer)
        {
            yield return null;

            count++;
        }

        popupMask.enabled = false;
    }

    private void HideInfo()
    {
        tooltipText.text = "";
        popupMask.enabled = true;
    }
}
