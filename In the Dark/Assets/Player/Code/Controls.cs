// GENERATED AUTOMATICALLY FROM 'Assets/Player/SOs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7098fcb3-51fd-4828-8442-7c3286b11a7a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""13e9a080-6740-441f-b495-1d534716e081"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryItem"",
                    ""type"": ""Button"",
                    ""id"": ""cace2297-1492-40fd-8ac9-0b2fc78502b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryItem"",
                    ""type"": ""Button"",
                    ""id"": ""3754ad7a-3f77-4866-a63c-ed5f21ad392e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""f7c72dfe-c1f7-4716-bdfc-81420e4314cc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Activate"",
                    ""type"": ""Button"",
                    ""id"": ""fb95af1d-d4b6-4351-b9f9-ca3718bb5f4a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""62d03f96-8b04-4b3e-9be8-ed7eae4d47de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ab47c733-acdd-4b06-8608-c80a4ca7c434"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27072e8a-6b53-4968-b2fc-f5a0f3309f1d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""PrimaryItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aec0b9a0-f9a7-4430-83c3-75f8a14c9eec"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SecondaryItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d428538-fc8a-473d-a4c6-c4feec319a4d"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SecondaryItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb24eb50-d899-4b89-8d86-fd422fdeec04"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d918583f-98cb-4aac-bdac-c7f0a7053271"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0f7a1cfd-847b-41df-a8d6-9ad0114c46d2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""93f54920-2bf8-4cc9-b1ba-81774bd85eaf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""88b82d02-a433-4b34-81a1-ce12636d0ea8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""224203f5-61df-40a9-a08d-8436c7da897e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a19da04-abde-4803-b0b3-57440d9292c7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee34c25b-8999-4468-9c67-9fe39a0f232d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bf41e60-e057-4962-b19a-3dd7a366e21d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ItemMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcaaefbb-0d2d-48a8-9cb4-1c145963ab5b"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ItemMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_PrimaryItem = m_Player.FindAction("PrimaryItem", throwIfNotFound: true);
        m_Player_SecondaryItem = m_Player.FindAction("SecondaryItem", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_Activate = m_Player.FindAction("Activate", throwIfNotFound: true);
        m_Player_PauseMenu = m_Player.FindAction("PauseMenu", throwIfNotFound: true);
        m_Player_ItemMenu = m_Player.FindAction("ItemMenu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_PrimaryItem;
    private readonly InputAction m_Player_SecondaryItem;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_Activate;
    private readonly InputAction m_Player_PauseMenu;
    private readonly InputAction m_Player_ItemMenu;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @PrimaryItem => m_Wrapper.m_Player_PrimaryItem;
        public InputAction @SecondaryItem => m_Wrapper.m_Player_SecondaryItem;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @Activate => m_Wrapper.m_Player_Activate;
        public InputAction @PauseMenu => m_Wrapper.m_Player_PauseMenu;
        public InputAction @ItemMenu => m_Wrapper.m_Player_ItemMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @PrimaryItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryItem;
                @PrimaryItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryItem;
                @PrimaryItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryItem;
                @SecondaryItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryItem;
                @SecondaryItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryItem;
                @SecondaryItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryItem;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Activate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnActivate;
                @Activate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnActivate;
                @Activate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnActivate;
                @PauseMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @ItemMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemMenu;
                @ItemMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemMenu;
                @ItemMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @PrimaryItem.started += instance.OnPrimaryItem;
                @PrimaryItem.performed += instance.OnPrimaryItem;
                @PrimaryItem.canceled += instance.OnPrimaryItem;
                @SecondaryItem.started += instance.OnSecondaryItem;
                @SecondaryItem.performed += instance.OnSecondaryItem;
                @SecondaryItem.canceled += instance.OnSecondaryItem;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Activate.started += instance.OnActivate;
                @Activate.performed += instance.OnActivate;
                @Activate.canceled += instance.OnActivate;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @ItemMenu.started += instance.OnItemMenu;
                @ItemMenu.performed += instance.OnItemMenu;
                @ItemMenu.canceled += instance.OnItemMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPrimaryItem(InputAction.CallbackContext context);
        void OnSecondaryItem(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnActivate(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnItemMenu(InputAction.CallbackContext context);
    }
}
