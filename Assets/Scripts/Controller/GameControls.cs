// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""bbec0846-0b6b-4cb1-a121-98ec92a3456e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c6e26b4e-4f6a-466c-a306-99b73fff1096"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a836e91c-80b7-4d8b-940c-6e9f567eae84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crounch"",
                    ""type"": ""Button"",
                    ""id"": ""ba8f473c-1280-441f-a032-95968225caf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Power_Switch"",
                    ""type"": ""Button"",
                    ""id"": ""bc5c1821-eb32-4256-9881-c96cc0ebb26b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Power_01"",
                    ""type"": ""Button"",
                    ""id"": ""4bb2bb3f-76a5-40b8-95fd-39ea2b243a77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Power_02"",
                    ""type"": ""Button"",
                    ""id"": ""7fe4cc17-5d75-4d5b-b084-43667dfb6a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Base_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""a107dd68-9989-4ca0-a1e7-42ecc5b5f82b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cb609316-372b-48be-a332-2fb0100d19e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""207ffd58-60b3-4d7c-94c9-24dedec1319b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dd109651-cb33-4578-99f6-edbabdb7d799"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""69215764-e609-42cf-bccb-659d0b083142"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""3a9693f6-1015-41e5-963d-9f32879d86e8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0f5ccab1-6c73-46af-a5e0-e6e7a22671b4"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e3573623-1356-4d10-a7a8-d3b4ecdea317"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e1703ead-d9cb-47ca-a4b0-98adccb8c532"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7362d0ed-8878-4d6f-a0b5-147af3e2efae"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c478889-7d2a-4ac6-80e9-08875ba1065b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crounch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""079a0612-3378-4b20-9a7b-cda0d4123026"",
                    ""path"": ""<XInputController>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crounch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef05d8d7-bd33-4250-a3ac-258183bc011e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2553c21f-89f8-44ae-bc26-03c2995eef9c"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7442d53e-403f-4b3f-988e-bccec5e810fa"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6678741d-8344-47fd-82e4-b7d21d70df87"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec36c426-e08c-45eb-a300-f03735f61221"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Hold(duration=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Base_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8669fa0-4f2c-459d-9224-de7f2e600504"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Hold(duration=0.4)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Base_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9acb530-bfb5-4a1b-a146-97de2721406d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""169be454-1850-4551-9a86-6af1339620d8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Power_Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ec6d4f2-7551-4116-9f57-9bb5c79b9800"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power_Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58455f9e-a245-4e06-b9ea-aa2f45dd7787"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Power_Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88981e03-4406-4cea-969f-7ad6285b93e7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a858546-474e-4729-803e-785d92b03c3c"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4ce14337-e121-4699-8b16-dae9d181318c"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5af8d689-a5ce-44e6-b46e-a5ae4f184a03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6e9f6c1a-8dd7-49b2-a156-8d8bc533b29a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Crounch = m_Gameplay.FindAction("Crounch", throwIfNotFound: true);
        m_Gameplay_Power_Switch = m_Gameplay.FindAction("Power_Switch", throwIfNotFound: true);
        m_Gameplay_Power_01 = m_Gameplay.FindAction("Power_01", throwIfNotFound: true);
        m_Gameplay_Power_02 = m_Gameplay.FindAction("Power_02", throwIfNotFound: true);
        m_Gameplay_Base_Attack = m_Gameplay.FindAction("Base_Attack", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Crounch;
    private readonly InputAction m_Gameplay_Power_Switch;
    private readonly InputAction m_Gameplay_Power_01;
    private readonly InputAction m_Gameplay_Power_02;
    private readonly InputAction m_Gameplay_Base_Attack;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private @GameControls m_Wrapper;
        public GameplayActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Crounch => m_Wrapper.m_Gameplay_Crounch;
        public InputAction @Power_Switch => m_Wrapper.m_Gameplay_Power_Switch;
        public InputAction @Power_01 => m_Wrapper.m_Gameplay_Power_01;
        public InputAction @Power_02 => m_Wrapper.m_Gameplay_Power_02;
        public InputAction @Base_Attack => m_Wrapper.m_Gameplay_Base_Attack;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Crounch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrounch;
                @Crounch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrounch;
                @Crounch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrounch;
                @Power_Switch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_Switch;
                @Power_Switch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_Switch;
                @Power_Switch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_Switch;
                @Power_01.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_01;
                @Power_01.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_01;
                @Power_01.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_01;
                @Power_02.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_02;
                @Power_02.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_02;
                @Power_02.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPower_02;
                @Base_Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBase_Attack;
                @Base_Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBase_Attack;
                @Base_Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBase_Attack;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crounch.started += instance.OnCrounch;
                @Crounch.performed += instance.OnCrounch;
                @Crounch.canceled += instance.OnCrounch;
                @Power_Switch.started += instance.OnPower_Switch;
                @Power_Switch.performed += instance.OnPower_Switch;
                @Power_Switch.canceled += instance.OnPower_Switch;
                @Power_01.started += instance.OnPower_01;
                @Power_01.performed += instance.OnPower_01;
                @Power_01.canceled += instance.OnPower_01;
                @Power_02.started += instance.OnPower_02;
                @Power_02.performed += instance.OnPower_02;
                @Power_02.canceled += instance.OnPower_02;
                @Base_Attack.started += instance.OnBase_Attack;
                @Base_Attack.performed += instance.OnBase_Attack;
                @Base_Attack.canceled += instance.OnBase_Attack;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @GameControls m_Wrapper;
        public UIActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrounch(InputAction.CallbackContext context);
        void OnPower_Switch(InputAction.CallbackContext context);
        void OnPower_01(InputAction.CallbackContext context);
        void OnPower_02(InputAction.CallbackContext context);
        void OnBase_Attack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
