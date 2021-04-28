// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Base/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Slider.Base
{
    public class @PlayerInputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""8a58b17b-a5ad-481a-b3b0-6ab1f08a3423"",
            ""actions"": [
                {
                    ""name"": ""PressTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3ef273c9-4afb-4454-9c30-d6593773dff2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ReleaseTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d22c05cf-f152-49ca-b4e5-f8ac8746b97c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""HoldTouch"",
                    ""type"": ""Value"",
                    ""id"": ""3c4d4f3f-64e1-4d8a-a08d-e7ac88934cb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65377f9e-b6f6-4b3e-9b6f-b085315743b9"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6a8d7f-67f6-41db-9f93-58b5dcc8362b"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f83c067a-4c9c-41a5-89dd-9e0d0db6b620"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39fe0749-541a-4a34-a274-b4b900a5029b"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fda88a45-1ebb-4af9-a911-f26171ab13dd"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerInput
            m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
            m_PlayerInput_PressTouch = m_PlayerInput.FindAction("PressTouch", throwIfNotFound: true);
            m_PlayerInput_ReleaseTouch = m_PlayerInput.FindAction("ReleaseTouch", throwIfNotFound: true);
            m_PlayerInput_HoldTouch = m_PlayerInput.FindAction("HoldTouch", throwIfNotFound: true);
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

        // PlayerInput
        private readonly InputActionMap m_PlayerInput;
        private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
        private readonly InputAction m_PlayerInput_PressTouch;
        private readonly InputAction m_PlayerInput_ReleaseTouch;
        private readonly InputAction m_PlayerInput_HoldTouch;
        public struct PlayerInputActions
        {
            private @PlayerInputs m_Wrapper;
            public PlayerInputActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @PressTouch => m_Wrapper.m_PlayerInput_PressTouch;
            public InputAction @ReleaseTouch => m_Wrapper.m_PlayerInput_ReleaseTouch;
            public InputAction @HoldTouch => m_Wrapper.m_PlayerInput_HoldTouch;
            public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerInputActions instance)
            {
                if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
                {
                    @PressTouch.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPressTouch;
                    @PressTouch.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPressTouch;
                    @PressTouch.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPressTouch;
                    @ReleaseTouch.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReleaseTouch;
                    @ReleaseTouch.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReleaseTouch;
                    @ReleaseTouch.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReleaseTouch;
                    @HoldTouch.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHoldTouch;
                    @HoldTouch.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHoldTouch;
                    @HoldTouch.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnHoldTouch;
                }
                m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PressTouch.started += instance.OnPressTouch;
                    @PressTouch.performed += instance.OnPressTouch;
                    @PressTouch.canceled += instance.OnPressTouch;
                    @ReleaseTouch.started += instance.OnReleaseTouch;
                    @ReleaseTouch.performed += instance.OnReleaseTouch;
                    @ReleaseTouch.canceled += instance.OnReleaseTouch;
                    @HoldTouch.started += instance.OnHoldTouch;
                    @HoldTouch.performed += instance.OnHoldTouch;
                    @HoldTouch.canceled += instance.OnHoldTouch;
                }
            }
        }
        public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
        public interface IPlayerInputActions
        {
            void OnPressTouch(InputAction.CallbackContext context);
            void OnReleaseTouch(InputAction.CallbackContext context);
            void OnHoldTouch(InputAction.CallbackContext context);
        }
    }
}
