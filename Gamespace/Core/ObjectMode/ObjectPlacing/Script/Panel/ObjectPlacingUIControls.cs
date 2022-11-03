// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/ObjectPlacing/Script/ObjectPlacingUIControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class @ObjectPlacingUIControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ObjectPlacingUIControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ObjectPlacingUIControls"",
    ""maps"": [
        {
            ""name"": ""SelectionPanel"",
            ""id"": ""ee177bb6-b9c0-48bc-beec-e240bb8435a7"",
            ""actions"": [
                {
                    ""name"": ""Open"",
                    ""type"": ""Button"",
                    ""id"": ""ef7bf415-0ee6-4682-afd3-a27efdc972ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""67097990-84d7-4ea9-a6a2-7f3cb026d7f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CatergoryMoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""313bb63c-00ca-4358-af73-c9b030965575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CatergoryMoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""1a159142-7913-46f9-ba54-b9f752511618"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff03108d-2d96-4f65-9f71-9832565f4b5f"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Open"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9169db9-fcc8-4e9a-934a-4f29f59376b4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89f0bdcb-99b4-4883-a4a6-343cf3680a69"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""CatergoryMoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd815c24-9a9b-41dd-803c-bedd0d52f80a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""CatergoryMoveLeft"",
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
            // SelectionPanel
            m_SelectionPanel = asset.FindActionMap("SelectionPanel", throwIfNotFound: true);
            m_SelectionPanel_Open = m_SelectionPanel.FindAction("Open", throwIfNotFound: true);
            m_SelectionPanel_Close = m_SelectionPanel.FindAction("Close", throwIfNotFound: true);
            m_SelectionPanel_CatergoryMoveRight = m_SelectionPanel.FindAction("CatergoryMoveRight", throwIfNotFound: true);
            m_SelectionPanel_CatergoryMoveLeft = m_SelectionPanel.FindAction("CatergoryMoveLeft", throwIfNotFound: true);
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

        // SelectionPanel
        private readonly InputActionMap m_SelectionPanel;
        private ISelectionPanelActions m_SelectionPanelActionsCallbackInterface;
        private readonly InputAction m_SelectionPanel_Open;
        private readonly InputAction m_SelectionPanel_Close;
        private readonly InputAction m_SelectionPanel_CatergoryMoveRight;
        private readonly InputAction m_SelectionPanel_CatergoryMoveLeft;
        public struct SelectionPanelActions
        {
            private @ObjectPlacingUIControls m_Wrapper;
            public SelectionPanelActions(@ObjectPlacingUIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Open => m_Wrapper.m_SelectionPanel_Open;
            public InputAction @Close => m_Wrapper.m_SelectionPanel_Close;
            public InputAction @CatergoryMoveRight => m_Wrapper.m_SelectionPanel_CatergoryMoveRight;
            public InputAction @CatergoryMoveLeft => m_Wrapper.m_SelectionPanel_CatergoryMoveLeft;
            public InputActionMap Get() { return m_Wrapper.m_SelectionPanel; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SelectionPanelActions set) { return set.Get(); }
            public void SetCallbacks(ISelectionPanelActions instance)
            {
                if (m_Wrapper.m_SelectionPanelActionsCallbackInterface != null)
                {
                    @Open.started -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnOpen;
                    @Open.performed -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnOpen;
                    @Open.canceled -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnOpen;
                    @Close.started -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnClose;
                    @Close.performed -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnClose;
                    @Close.canceled -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnClose;
                    @CatergoryMoveRight.started -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveRight;
                    @CatergoryMoveRight.performed -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveRight;
                    @CatergoryMoveRight.canceled -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveRight;
                    @CatergoryMoveLeft.started -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveLeft;
                    @CatergoryMoveLeft.performed -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveLeft;
                    @CatergoryMoveLeft.canceled -= m_Wrapper.m_SelectionPanelActionsCallbackInterface.OnCatergoryMoveLeft;
                }
                m_Wrapper.m_SelectionPanelActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Open.started += instance.OnOpen;
                    @Open.performed += instance.OnOpen;
                    @Open.canceled += instance.OnOpen;
                    @Close.started += instance.OnClose;
                    @Close.performed += instance.OnClose;
                    @Close.canceled += instance.OnClose;
                    @CatergoryMoveRight.started += instance.OnCatergoryMoveRight;
                    @CatergoryMoveRight.performed += instance.OnCatergoryMoveRight;
                    @CatergoryMoveRight.canceled += instance.OnCatergoryMoveRight;
                    @CatergoryMoveLeft.started += instance.OnCatergoryMoveLeft;
                    @CatergoryMoveLeft.performed += instance.OnCatergoryMoveLeft;
                    @CatergoryMoveLeft.canceled += instance.OnCatergoryMoveLeft;
                }
            }
        }
        public SelectionPanelActions @SelectionPanel => new SelectionPanelActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface ISelectionPanelActions
        {
            void OnOpen(InputAction.CallbackContext context);
            void OnClose(InputAction.CallbackContext context);
            void OnCatergoryMoveRight(InputAction.CallbackContext context);
            void OnCatergoryMoveLeft(InputAction.CallbackContext context);
        }
    }
}
