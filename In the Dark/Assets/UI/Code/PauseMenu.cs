using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour, IAmMenu
{
    public event Action<IAmMenu> RequestToggleCallback;

    private Controls controls;

    [SerializeField] private GameObject menu = null;
    [SerializeField] private bool stacksWithOtherMenus = true;


    public bool IsOpen { get; private set; }

    public bool StacksWithOtherMenus => stacksWithOtherMenus;


    private void Awake()
    {
        controls = new Controls();
        controls.Player.PauseMenu.performed += (ctx) => { InvokeRequestToggleCallback(); };
    }

    private void OnEnable() => controls.Enable();

    private void OnDisable() => controls.Disable();


    public void Toggle(bool toggle)
    {
        menu.gameObject.SetActive(toggle);

        IsOpen = toggle;

        ChangeTimeScale(toggle ? 0f : 1f);
    }

    private void ChangeTimeScale(float amount)
    {
        Time.timeScale = amount;
    }

    public void QuitToMainMenu()
    {
        ChangeTimeScale(1f);

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop()
    {
        ChangeTimeScale(1f);

        Application.Quit();
    }

    public void InvokeRequestToggleCallback() => RequestToggleCallback?.Invoke(this);
}
