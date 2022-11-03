// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/ObjectMode/ObjectSelection/ObjectSelectionControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class @ObjectSelectionControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ObjectSelectionControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ObjectSelectionControls"",
    ""maps"": [
        {
            ""name"": ""Panel"",
            ""id"": ""93b7d23d-ae65-4077-863d-3bf29b171c7d"",
            ""actions"": [
                {
                    ""name"": ""Open"",
                    ""type"": ""Button"",
                    ""id"": ""be058434-74cb-4743-9d0a-0a0773a2321a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fea518ad-ba8c-45a4-b15a-986ac8309838"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Open"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shortcuts"",
            ""id"": ""3bc0d8d6-b501-46d6-a2d5-49783deb04f4"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""dcf934a5-1abc-4678-87d9-11bc68641733"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Elevate"",
                    ""type"": ""Button"",
                    ""id"": ""bf52f230-dff4-4879-a4b0-8cdc871eba22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e6c2575-b87d-4a24-bf2f-078b8f7d050e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02a7bf7f-1f05-4dca-ab3a-786435ef570c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Elevate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
            // Panel
            m_Panel = asset.FindActionMap("Panel", throwIfNotFound: true);
            m_Panel_Open = m_Panel.FindAction("Open", throwIfNotFound: true);
            // Shortcuts
            m_Shortcuts = asset.FindActionMap("Shortcuts", throwIfNotFound: true);
            m_Shortcuts_Rotate = m_Shortcuts.FindAction("Rotate", throwIfNotFound: true);
            m_Shortcuts_Elevate = m_Shortcuts.FindAction("Elevate", throwIfNotFound: true);
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

        // Panel
        private readonly InputActionMap m_Panel;
        private IPanelActions m_PanelActionsCallbackInterface;
        private readonly InputAction m_Panel_Open;
        public struct PanelActions
        {
            private @ObjectSelectionControls m_Wrapper;
            public PanelActions(@ObjectSelectionControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Open => m_Wrapper.m_Panel_Open;
            public InputActionMap Get() { return m_Wrapper.m_Panel; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PanelActions set) { return set.Get(); }
            public void SetCallbacks(IPanelActions instance)
            {
                if (m_Wrapper.m_PanelActionsCallbackInterface != null)
                {
                    @Open.started -= m_Wrapper.m_PanelActionsCallbackInterface.OnOpen;
                    @Open.performed -= m_Wrapper.m_PanelActionsCallbackInterface.OnOpen;
                    @Open.canceled -= m_Wrapper.m_PanelActionsCallbackInterface.OnOpen;
                }
                m_Wrapper.m_PanelActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Open.started += instance.OnOpen;
                    @Open.performed += instance.OnOpen;
                    @Open.canceled += instance.OnOpen;
                }
            }
        }
        public PanelActions @Panel => new PanelActions(this);

        // Shortcuts
        private readonly InputActionMap m_Shortcuts;
        private IShortcutsActions m_ShortcutsActionsCallbackInterface;
        private readonly InputAction m_Shortcuts_Rotate;
        private readonly InputAction m_Shortcuts_Elevate;
        public struct ShortcutsActions
        {
            private @ObjectSelectionControls m_Wrapper;
            public ShortcutsActions(@ObjectSelectionControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotate => m_Wrapper.m_Shortcuts_Rotate;
            public InputAction @Elevate => m_Wrapper.m_Shortcuts_Elevate;
            public InputActionMap Get() { return m_Wrapper.m_Shortcuts; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShortcutsActions set) { return set.Get(); }
            public void SetCallbacks(IShortcutsActions instance)
            {
                if (m_Wrapper.m_ShortcutsActionsCallbackInterface != null)
                {
                    @Rotate.started -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnRotate;
                    @Elevate.started -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnElevate;
                    @Elevate.performed -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnElevate;
                    @Elevate.canceled -= m_Wrapper.m_ShortcutsActionsCallbackInterface.OnElevate;
                }
                m_Wrapper.m_ShortcutsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @Elevate.started += instance.OnElevate;
                    @Elevate.performed += instance.OnElevate;
                    @Elevate.canceled += instance.OnElevate;
                }
            }
        }
        public ShortcutsActions @Shortcuts => new ShortcutsActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface IPanelActions
        {
            void OnOpen(InputAction.CallbackContext context);
        }
        public interface IShortcutsActions
        {
            void OnRotate(InputAction.CallbackContext context);
            void OnElevate(InputAction.CallbackContext context);
        }
    }
}
