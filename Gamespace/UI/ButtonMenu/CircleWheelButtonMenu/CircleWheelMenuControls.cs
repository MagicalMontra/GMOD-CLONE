// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/UI/ButtonMenu/CircleWheelButtonMenu/CircleWheelMenuControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.UI
{
    public class @CircleWheelMenuControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CircleWheelMenuControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CircleWheelMenuControls"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""45cede58-c736-4d72-a494-38ffb7039a31"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""fdaf6520-38e1-406a-844a-1ec7e36a3853"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Execute"",
                    ""type"": ""Button"",
                    ""id"": ""c1088903-28ed-4d1d-a934-a523edcdf9f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""5e090ce2-ebcd-4035-8ff1-9c4e0fbe6265"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PageChange"",
                    ""type"": ""Button"",
                    ""id"": ""27385117-2eb9-40d4-bf1b-6a665e0b19a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""555b52df-9e51-4019-92f3-79d9064e3a19"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff90065e-4515-4028-912d-fedba5a23294"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Execute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a20b4abf-15d1-4060-973a-c951e31bea31"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6841998a-3111-4e07-b7a0-58212f2a11b7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PageChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d4c57df0-563a-4ca5-81fb-8d32778da0ea"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PageChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d48a6ee4-cd15-4652-b7de-85cada0ba253"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PageChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
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
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_MousePosition = m_UI.FindAction("MousePosition", throwIfNotFound: true);
            m_UI_Execute = m_UI.FindAction("Execute", throwIfNotFound: true);
            m_UI_Exit = m_UI.FindAction("Exit", throwIfNotFound: true);
            m_UI_PageChange = m_UI.FindAction("PageChange", throwIfNotFound: true);
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

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_MousePosition;
        private readonly InputAction m_UI_Execute;
        private readonly InputAction m_UI_Exit;
        private readonly InputAction m_UI_PageChange;
        public struct UIActions
        {
            private @CircleWheelMenuControls m_Wrapper;
            public UIActions(@CircleWheelMenuControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_UI_MousePosition;
            public InputAction @Execute => m_Wrapper.m_UI_Execute;
            public InputAction @Exit => m_Wrapper.m_UI_Exit;
            public InputAction @PageChange => m_Wrapper.m_UI_PageChange;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @MousePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePosition;
                    @Execute.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExecute;
                    @Execute.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExecute;
                    @Execute.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExecute;
                    @Exit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                    @PageChange.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPageChange;
                    @PageChange.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPageChange;
                    @PageChange.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPageChange;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @Execute.started += instance.OnExecute;
                    @Execute.performed += instance.OnExecute;
                    @Execute.canceled += instance.OnExecute;
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                    @PageChange.started += instance.OnPageChange;
                    @PageChange.performed += instance.OnPageChange;
                    @PageChange.canceled += instance.OnPageChange;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface IUIActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnExecute(InputAction.CallbackContext context);
            void OnExit(InputAction.CallbackContext context);
            void OnPageChange(InputAction.CallbackContext context);
        }
    }
}
