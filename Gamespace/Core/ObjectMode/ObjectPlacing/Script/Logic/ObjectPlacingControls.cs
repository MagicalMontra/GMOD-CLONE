// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/ObjectMode/ObjectPlacing/Script/Logic/ObjectPlacingControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class @ObjectPlacingControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ObjectPlacingControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ObjectPlacingControls"",
    ""maps"": [
        {
            ""name"": ""ObjectPlacing"",
            ""id"": ""70f7831d-350a-4946-b358-877656ca5c27"",
            ""actions"": [
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""25bb6fd0-2df2-4fd6-84d8-a15a860a4ce5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""00827aec-c819-4387-8f96-0bbaec1fe766"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlaceWithSnap"",
                    ""type"": ""Button"",
                    ""id"": ""3704b7ce-c605-4229-adbd-6c2663ef2fc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7b52326-7118-40b1-a478-de629013e6c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cc82518-60a0-45c9-adaf-357f5b0c0124"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""7d2c423e-9c93-4376-ac9e-5217d6b03abe"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceWithSnap"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7b58370d-5898-49bd-bd43-cbcaafbd917a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PlaceWithSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""44fe6c2b-03e0-4144-ade1-cf542914e40b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PlaceWithSnap"",
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
        },
        {
            ""name"": ""VR"",
            ""bindingGroup"": ""VR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // ObjectPlacing
            m_ObjectPlacing = asset.FindActionMap("ObjectPlacing", throwIfNotFound: true);
            m_ObjectPlacing_Place = m_ObjectPlacing.FindAction("Place", throwIfNotFound: true);
            m_ObjectPlacing_Exit = m_ObjectPlacing.FindAction("Exit", throwIfNotFound: true);
            m_ObjectPlacing_PlaceWithSnap = m_ObjectPlacing.FindAction("PlaceWithSnap", throwIfNotFound: true);
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

        // ObjectPlacing
        private readonly InputActionMap m_ObjectPlacing;
        private IObjectPlacingActions m_ObjectPlacingActionsCallbackInterface;
        private readonly InputAction m_ObjectPlacing_Place;
        private readonly InputAction m_ObjectPlacing_Exit;
        private readonly InputAction m_ObjectPlacing_PlaceWithSnap;
        public struct ObjectPlacingActions
        {
            private @ObjectPlacingControls m_Wrapper;
            public ObjectPlacingActions(@ObjectPlacingControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Place => m_Wrapper.m_ObjectPlacing_Place;
            public InputAction @Exit => m_Wrapper.m_ObjectPlacing_Exit;
            public InputAction @PlaceWithSnap => m_Wrapper.m_ObjectPlacing_PlaceWithSnap;
            public InputActionMap Get() { return m_Wrapper.m_ObjectPlacing; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ObjectPlacingActions set) { return set.Get(); }
            public void SetCallbacks(IObjectPlacingActions instance)
            {
                if (m_Wrapper.m_ObjectPlacingActionsCallbackInterface != null)
                {
                    @Place.started -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlace;
                    @Place.performed -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlace;
                    @Place.canceled -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlace;
                    @Exit.started -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnExit;
                    @PlaceWithSnap.started -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlaceWithSnap;
                    @PlaceWithSnap.performed -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlaceWithSnap;
                    @PlaceWithSnap.canceled -= m_Wrapper.m_ObjectPlacingActionsCallbackInterface.OnPlaceWithSnap;
                }
                m_Wrapper.m_ObjectPlacingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Place.started += instance.OnPlace;
                    @Place.performed += instance.OnPlace;
                    @Place.canceled += instance.OnPlace;
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                    @PlaceWithSnap.started += instance.OnPlaceWithSnap;
                    @PlaceWithSnap.performed += instance.OnPlaceWithSnap;
                    @PlaceWithSnap.canceled += instance.OnPlaceWithSnap;
                }
            }
        }
        public ObjectPlacingActions @ObjectPlacing => new ObjectPlacingActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        private int m_VRSchemeIndex = -1;
        public InputControlScheme VRScheme
        {
            get
            {
                if (m_VRSchemeIndex == -1) m_VRSchemeIndex = asset.FindControlSchemeIndex("VR");
                return asset.controlSchemes[m_VRSchemeIndex];
            }
        }
        public interface IObjectPlacingActions
        {
            void OnPlace(InputAction.CallbackContext context);
            void OnExit(InputAction.CallbackContext context);
            void OnPlaceWithSnap(InputAction.CallbackContext context);
        }
    }
}
