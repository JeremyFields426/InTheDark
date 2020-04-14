using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour, IAmMenu
{
    public event Action<IAmMenu> RequestToggleCallback;

    private List<Resolution> allResolutions = new List<Resolution>();

    [SerializeField] private GameObject menu = null;
    [SerializeField] private TMP_Dropdown resolutionDropdown = null;
    [SerializeField] private AudioMixer mainMixer = null;
    [SerializeField] private bool stacksWithOtherMenus = true;


    public bool IsOpen { get; private set; }

    public bool StacksWithOtherMenus => stacksWithOtherMenus;


    private void Start()
    {
        AddResolutions();
        PopulateResolutionDropdown();
    }

    public void Toggle(bool toggle)
    {
        menu.gameObject.SetActive(toggle);

        IsOpen = toggle;
    }

    private void AddResolutions()
    {
        foreach (Resolution resolution in Screen.resolutions)
        {
            if (!allResolutions.Contains(resolution))
            {
                allResolutions.Add(resolution);
            }
        }
    }

    private void PopulateResolutionDropdown()
    {
        List<string> resolutions = new List<string>();
        int currentResolutionIndex = 0;

        foreach (Resolution resolution in allResolutions)
        {
            resolutions.Add($"{resolution.width} x {resolution.height}");

            if (resolution.width == Screen.currentResolution.width && resolution.height == resolution.height)
            {
                currentResolutionIndex = resolutions.Count - 1;
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void AdjustVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", volume);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int index)
    {
        Screen.SetResolution(allResolutions[index].width, allResolutions[index].height, Screen.fullScreen);
    }

    public void InvokeRequestToggleCallback() => RequestToggleCallback?.Invoke(this);
}
