// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/ObjectRotate/ObjectRotateControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class @ObjectRotateControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ObjectRotateControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ObjectRotateControls"",
    ""maps"": [
        {
            ""name"": ""Rotate"",
            ""id"": ""7f9d15c6-073b-438f-b8d6-5aebc032db4d"",
            ""actions"": [
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""7cc696a5-e956-4cc8-aaf7-a6f5951d83d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""cd9c2619-9ce9-430c-b34c-4b0b78be6893"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""2a62aa21-4327-4ecd-a328-b23b6658df03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""94466ee1-2c22-45e5-a0dd-e1b846cc54f9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""055dd2d9-e5bb-415a-946c-8670e8add08d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fac05e98-d50b-4e4c-abc0-f6ade1bb543a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""91cb948a-fda6-4a54-99bb-435bcec519c4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Y"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4accfd7a-2a01-4214-9287-ae4e323cd128"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9e0e4d9-e3f4-4cf3-927b-64f267839085"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""163fbb90-8f2c-4678-a172-f2400340f0d9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Z"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""396c0180-f142-4c5b-9d8c-f0715beea9ec"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c516a592-4029-4e24-9a6d-905d3553f910"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Other"",
            ""id"": ""dd1c2609-6e67-4f76-8548-6b073812f330"",
            ""actions"": [
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""b8bcbb28-1587-4641-95b4-983a17b44515"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""84ca5760-802e-44ce-865a-b4638df782e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""787519bc-bc67-4b8a-bbd8-08af84783659"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ff631ae-3abf-4334-99d5-636d6d09e757"",
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
                    ""id"": ""ba2dc958-4bae-4b34-b0f8-527c78708eb9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be2e9cb2-de22-46bb-a532-533bb0b610c7"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Switch"",
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
            // Rotate
            m_Rotate = asset.FindActionMap("Rotate", throwIfNotFound: true);
            m_Rotate_X = m_Rotate.FindAction("X", throwIfNotFound: true);
            m_Rotate_Y = m_Rotate.FindAction("Y", throwIfNotFound: true);
            m_Rotate_Z = m_Rotate.FindAction("Z", throwIfNotFound: true);
            // Other
            m_Other = asset.FindActionMap("Other", throwIfNotFound: true);
            m_Other_Switch = m_Other.FindAction("Switch", throwIfNotFound: true);
            m_Other_Reset = m_Other.FindAction("Reset", throwIfNotFound: true);
            m_Other_Exit = m_Other.FindAction("Exit", throwIfNotFound: true);
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

        // Rotate
        private readonly InputActionMap m_Rotate;
        private IRotateActions m_RotateActionsCallbackInterface;
        private readonly InputAction m_Rotate_X;
        private readonly InputAction m_Rotate_Y;
        private readonly InputAction m_Rotate_Z;
        public struct RotateActions
        {
            private @ObjectRotateControls m_Wrapper;
            public RotateActions(@ObjectRotateControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @X => m_Wrapper.m_Rotate_X;
            public InputAction @Y => m_Wrapper.m_Rotate_Y;
            public InputAction @Z => m_Wrapper.m_Rotate_Z;
            public InputActionMap Get() { return m_Wrapper.m_Rotate; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RotateActions set) { return set.Get(); }
            public void SetCallbacks(IRotateActions instance)
            {
                if (m_Wrapper.m_RotateActionsCallbackInterface != null)
                {
                    @X.started -= m_Wrapper.m_RotateActionsCallbackInterface.OnX;
                    @X.performed -= m_Wrapper.m_RotateActionsCallbackInterface.OnX;
                    @X.canceled -= m_Wrapper.m_RotateActionsCallbackInterface.OnX;
                    @Y.started -= m_Wrapper.m_RotateActionsCallbackInterface.OnY;
                    @Y.performed -= m_Wrapper.m_RotateActionsCallbackInterface.OnY;
                    @Y.canceled -= m_Wrapper.m_RotateActionsCallbackInterface.OnY;
                    @Z.started -= m_Wrapper.m_RotateActionsCallbackInterface.OnZ;
                    @Z.performed -= m_Wrapper.m_RotateActionsCallbackInterface.OnZ;
                    @Z.canceled -= m_Wrapper.m_RotateActionsCallbackInterface.OnZ;
                }
                m_Wrapper.m_RotateActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @X.started += instance.OnX;
                    @X.performed += instance.OnX;
                    @X.canceled += instance.OnX;
                    @Y.started += instance.OnY;
                    @Y.performed += instance.OnY;
                    @Y.canceled += instance.OnY;
                    @Z.started += instance.OnZ;
                    @Z.performed += instance.OnZ;
                    @Z.canceled += instance.OnZ;
                }
            }
        }
        public RotateActions @Rotate => new RotateActions(this);

        // Other
        private readonly InputActionMap m_Other;
        private IOtherActions m_OtherActionsCallbackInterface;
        private readonly InputAction m_Other_Switch;
        private readonly InputAction m_Other_Reset;
        private readonly InputAction m_Other_Exit;
        public struct OtherActions
        {
            private @ObjectRotateControls m_Wrapper;
            public OtherActions(@ObjectRotateControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Switch => m_Wrapper.m_Other_Switch;
            public InputAction @Reset => m_Wrapper.m_Other_Reset;
            public InputAction @Exit => m_Wrapper.m_Other_Exit;
            public InputActionMap Get() { return m_Wrapper.m_Other; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OtherActions set) { return set.Get(); }
            public void SetCallbacks(IOtherActions instance)
            {
                if (m_Wrapper.m_OtherActionsCallbackInterface != null)
                {
                    @Switch.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnSwitch;
                    @Switch.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnSwitch;
                    @Switch.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnSwitch;
                    @Reset.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                    @Reset.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                    @Reset.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnReset;
                    @Exit.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnExit;
                }
                m_Wrapper.m_OtherActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Switch.started += instance.OnSwitch;
                    @Switch.performed += instance.OnSwitch;
                    @Switch.canceled += instance.OnSwitch;
                    @Reset.started += instance.OnReset;
                    @Reset.performed += instance.OnReset;
                    @Reset.canceled += instance.OnReset;
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
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
        public interface IRotateActions
        {
            void OnX(InputAction.CallbackContext context);
            void OnY(InputAction.CallbackContext context);
            void OnZ(InputAction.CallbackContext context);
        }
        public interface IOtherActions
        {
            void OnSwitch(InputAction.CallbackContext context);
            void OnReset(InputAction.CallbackContext context);
            void OnExit(InputAction.CallbackContext context);
        }
    }
}
