using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    private DoublyLinkedList<IAmMenu> openedMenus = new DoublyLinkedList<IAmMenu>();

    [SerializeField] private State playerState = null;


    private void Awake()
    {
        RegisterCallbacks();
    }

    private void RegisterCallbacks()
    {
        // TODO: This will not work for GameObjects that are inactive.
        foreach (IAmMenu menu in FindObjectsOfType<MonoBehaviour>().OfType<IAmMenu>())
        {
            menu.RequestToggleCallback += OnMenuRequest;
        }
    }

    private void OnMenuRequest(IAmMenu menu)
    {
        if (openedMenus.Count > 0)
        {
            if (menu.StacksWithOtherMenus && !menu.IsOpen)
            {
                // TODO: Need a way of ordering the menus on screen
                openedMenus.Push(menu);
                menu.Toggle(true);
            }
            else
            {
                // TODO: Need a way of doing explicit closing
                IAmMenu closedMenu = openedMenus.Pop();
                closedMenu.Toggle(false);

                if (openedMenus.Count == 0)
                {
                    if (closedMenu == menu)
                    {
                        playerState.IsBusy = false;
                    }
                    else
                    {
                        openedMenus.Push(menu);
                        menu.Toggle(true);
                    }
                }
            }
        }
        else if (openedMenus.Count == 0 && !playerState.IsBusy)
        {
            openedMenus.Push(menu);
            menu.Toggle(true);
            playerState.IsBusy = true;
        }
    }
}
