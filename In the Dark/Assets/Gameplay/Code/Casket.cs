using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class Casket : MonoBehaviour, IActivate, IGiveInfo
{
    public event Action<Casket> CasketActivatedCallback;

    private Animator anim;

    private bool isOpen;
    private int currentSpawnLocation;

    [SerializeField] private GameObject lanternLight = null;
    [SerializeField] private Light2D casketGlow = null;
    [SerializeField] private Transform[] spawnLocations = null;


    public bool CanActivate { get; private set; }

    public CasketData CasketData { get; private set; }

    public Vector3 NewSpawnLocation => spawnLocations[currentSpawnLocation++ % spawnLocations.Length].position;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        lanternLight.SetActive(false);
    }

    public string GetInfo()
    {
        if (!CanActivate || CasketData == null) { return "Empty Grave"; }

        return CasketData.GetInfo();
    }

    public void SetActivation(CasketData casketData)
    {
        CasketData = casketData;

        if (isOpen)
        {
            lanternLight.SetActive(false);
            anim.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            anim.SetTrigger("StartGlowing");
        }

        CanActivate = true;
        casketGlow.color = CasketData.CasketColor;
    }

    public void ResetCasket()
    {
        if (isOpen)
        {
            lanternLight.SetActive(true);
            anim.SetTrigger("Open");
        }
        else
        {
            anim.SetTrigger("StopGlowing");
        }

        CanActivate = false;
    }

    public void Activate()
    {
        isOpen = true;

        CasketActivatedCallback?.Invoke(this);
    }
}
