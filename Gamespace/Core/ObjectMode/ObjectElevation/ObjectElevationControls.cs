// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/ObjectElevation/ObjectElevationControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class @ObjectElevationControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ObjectElevationControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ObjectElevationControls"",
    ""maps"": [
        {
            ""name"": ""Elevation"",
            ""id"": ""965820be-fede-45a5-9968-169a1241845a"",
            ""actions"": [
                {
                    ""name"": ""Elevate/Descend"",
                    ""type"": ""Value"",
                    ""id"": ""cc9de544-6e37-4a6b-b295-8f84b23bd02b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerElevate/DescendModifier"",
                    ""type"": ""Button"",
                    ""id"": ""d7c462d8-6e09-4572-ba36-4e8fb2857161"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f0ebdbc-b1dc-4fda-a7e3-a96672267b57"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Elevate/Descend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dc9036e-e034-4554-8284-a5331d81b548"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PowerElevate/DescendModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Other"",
            ""id"": ""e43b70bb-a833-4655-9234-228cff130f62"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""e00e8e4d-aafd-4803-b4d6-4423ace1f07f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""81b838d2-fe6c-465b-92df-7449b0c5b61b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a3bf6de1-d17b-4f4c-a08c-98d175a1390f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0c22c2f-f527-4d04-b117-f7021c9b439f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Reset"",
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
            // Elevation
            m_Elevation = asset.FindActionMap("Elevation", throwIfNotFound: true);
            m_Elevation_ElevateDescend = m_Elevation.FindAction("Elevate/Descend", throwIfNotFound: true);
            m_Elevation_PowerElevateDescendModifier = m_Elevation.FindAction("PowerElevate/DescendModifier", throwIfNotFound: true);
            // Other
            m_Other = asset.FindActionMap("Other", throwIfNotFound: true);
            m_Other_Exit = m_Other.FindAction("Exit", throwIfNotFound: true);
            m_Other_Reset = m_Other.FindAction("Reset", throwIfNotFound: true);
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

        // Elevation
        private readonly InputActionMap m_Elevation;
        private IElevationActions m_ElevationActionsCallbackInterface;
        private readonly InputAction m_Elevation_ElevateDescend;
        private readonly InputAction m_Elevation_PowerElevateDescendModifier;
        public struct ElevationActions
        {
            private @ObjectElevationControls m_Wrapper;
            public ElevationActions(@ObjectElevationControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ElevateDescend => m_Wrapper.m_Elevation_ElevateDescend;
            public InputAction @PowerElevateDescendModifier => m_Wrapper.m_Elevation_PowerElevateDescendModifier;
            public InputActionMap Get() { return m_Wrapper.m_Elevation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ElevationActions set) { return set.Get(); }
            public void SetCallbacks(IElevationActions instance)
            {
                if (m_Wrapper.m_ElevationActionsCallbackInterface != null)
                {
                    @ElevateDescend.started -= m_Wrapper.m_ElevationActionsCallbackInterface.OnElevateDescend;
                    @ElevateDescend.performed -= m_Wrapper.m_ElevationActionsCallbackInterface.OnElevateDescend;
                    @ElevateDescend.canceled -= m_Wrapper.m_ElevationActionsCallbackInterface.OnElevateDescend;
                    @PowerElevateDescendModifier.started -= m_Wrapper.m_ElevationActionsCallbackInterface.OnPowerElevateDescendModifier;
                    @PowerElevateDescendModifier.performed -= m_Wrapper.m_ElevationActionsCallbackInterface.OnPowerElevateDescendModifier;
                    @PowerElevateDescendModifier.canceled -= m_Wrapper.m_ElevationActionsCallbackInterface.OnPowerElevateDescendModifier;
                }
                m_Wrapper.m_ElevationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ElevateDescend.started += instance.OnElevateDescend;
                    @ElevateDescend.performed += instance.OnElevateDescend;
                    @ElevateDescend.canceled += instance.OnElevateDescend;
                    @PowerElevateDescendModifier.started += instance.OnPowerElevateDescendModifier;
                    @PowerElevateDescendModifier.performed += instance.OnPowerElevateDescendModifier;
                    @PowerElevateDescendModifier.canceled += instance.OnPowerElevateDescendModifier;
                }
            }
        }
        public ElevationActions @Elevation => new ElevationActions(this);

        // Other
        private readonly InputActionMap m_Other;
        private IOtherActions m_OtherActionsCallbackInterface;
        private readonly InputAction m_Other_Exit;
        private readonly InputAction m_Other_Reset;
        public struct OtherActions
        {
            private @ObjectElevationControls m_Wrapper;
            public OtherActions(@ObjectElevationControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Exit => m_Wrapper.m_Other_Exit;
            public InputAction @Reset => m_Wrapper.m_Other_Reset;
            public InputActionMap Get() { return m_Wrapper.m_Other; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OtherActions set) { return set.Get(); }
            public void SetCallbacks(IOtherActions instance)
            {
                if (m_Wrapper.m_OtherActionsCallbackInterface != null)
                {
                    @Exit.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                    @Reset.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                    @Reset.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                    @Reset.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                }
                m_Wrapper.m_OtherActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                    @Reset.started += instance.OnReset;
                    @Reset.performed += instance.OnReset;
                    @Reset.canceled += instance.OnReset;
                }
            }
        }
        public OtherActions @Other => new OtherActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface IElevationActions
        {
            void OnElevateDescend(InputAction.CallbackContext context);
            void OnPowerElevateDescendModifier(InputAction.CallbackContext context);
        }
        public interface IOtherActions
        {
            void OnExit(InputAction.CallbackContext context);
            void OnReset(InputAction.CallbackContext context);
        }
    }
}
