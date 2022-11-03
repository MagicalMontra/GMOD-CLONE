// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/Blueprint/BlueprintInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.Blueprint
{
    public class @BlueprintInputControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @BlueprintInputControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""BlueprintInputControls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""df4faf56-b36c-4d62-9c8d-feefc93d8555"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fdbe8d5f-fdcb-40fa-8e43-4c21f523b6bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""237112b8-13ac-43f4-8345-ad9687525dd1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FloorSliderUp"",
                    ""type"": ""Button"",
                    ""id"": ""18497128-4a43-42b7-b557-4d3398646411"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FloorSliderDown"",
                    ""type"": ""Button"",
                    ""id"": ""1d985a68-750f-484c-9a15-595ce3227fb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c10f861e-7299-4f4a-8494-2e8041b8bb03"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a959b49-a1ea-4008-8e15-b32d92437c5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a4cc9f24-135f-4697-ae75-cdf1f402e90c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e5178478-e019-401d-bb82-6cefea81bf54"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a3196b3-9d49-4e4a-bdca-41e0ea9c657a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""caed8656-5403-4cfe-b379-8f323bed3999"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90f635a1-ab2f-407e-806e-1eee316a668b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FloorSliderUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64f0dbe6-529e-4623-9dd7-279bbbf475f1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FloorSliderDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Room"",
            ""id"": ""56101111-571f-4085-82d1-95faa78e47c0"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""e06a23c8-f2ff-4cfc-88a9-3bb0c0d20eaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1f0aba6e-b50d-478b-baf3-a4ce19bdd8a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TogglePanel"",
                    ""type"": ""Button"",
                    ""id"": ""e5385a83-1edc-4632-b609-44c6303b3a9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Remove"",
                    ""type"": ""Button"",
                    ""id"": ""31d5cb11-1198-4772-8bba-04ba0abd6d4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""d23f5a5a-c2d6-40d2-8629-b26108c3ae0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b2869da-057a-4c03-92b0-bb0ed7902002"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1cc396b-d54e-490c-bb48-8255e6c32844"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c5862df-ff95-4d86-b5f5-fc4f7a4e57e7"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caa6429e-62c3-4c19-9a5f-e534231663b1"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Remove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7341a8e0-3429-4363-9dc4-fa4f2bfa06e4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
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
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
            m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
            m_Camera_FloorSliderUp = m_Camera.FindAction("FloorSliderUp", throwIfNotFound: true);
            m_Camera_FloorSliderDown = m_Camera.FindAction("FloorSliderDown", throwIfNotFound: true);
            // Room
            m_Room = asset.FindActionMap("Room", throwIfNotFound: true);
            m_Room_Selection = m_Room.FindAction("Selection", throwIfNotFound: true);
            m_Room_Move = m_Room.FindAction("Move", throwIfNotFound: true);
            m_Room_TogglePanel = m_Room.FindAction("TogglePanel", throwIfNotFound: true);
            m_Room_Remove = m_Room.FindAction("Remove", throwIfNotFound: true);
            m_Room_Rotate = m_Room.FindAction("Rotate", throwIfNotFound: true);
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

        // Camera
        private readonly InputActionMap m_Camera;
        private ICameraActions m_CameraActionsCallbackInterface;
        private readonly InputAction m_Camera_Move;
        private readonly InputAction m_Camera_Zoom;
        private readonly InputAction m_Camera_FloorSliderUp;
        private readonly InputAction m_Camera_FloorSliderDown;
        public struct CameraActions
        {
            private @BlueprintInputControls m_Wrapper;
            public CameraActions(@BlueprintInputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Camera_Move;
            public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
            public InputAction @FloorSliderUp => m_Wrapper.m_Camera_FloorSliderUp;
            public InputAction @FloorSliderDown => m_Wrapper.m_Camera_FloorSliderDown;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void SetCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                    @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @FloorSliderUp.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderUp;
                    @FloorSliderUp.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderUp;
                    @FloorSliderUp.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderUp;
                    @FloorSliderDown.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderDown;
                    @FloorSliderDown.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderDown;
                    @FloorSliderDown.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnFloorSliderDown;
                }
                m_Wrapper.m_CameraActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Zoom.started += instance.OnZoom;
                    @Zoom.performed += instance.OnZoom;
                    @Zoom.canceled += instance.OnZoom;
                    @FloorSliderUp.started += instance.OnFloorSliderUp;
                    @FloorSliderUp.performed += instance.OnFloorSliderUp;
                    @FloorSliderUp.canceled += instance.OnFloorSliderUp;
                    @FloorSliderDown.started += instance.OnFloorSliderDown;
                    @FloorSliderDown.performed += instance.OnFloorSliderDown;
                    @FloorSliderDown.canceled += instance.OnFloorSliderDown;
                }
            }
        }
        public CameraActions @Camera => new CameraActions(this);

        // Room
        private readonly InputActionMap m_Room;
        private IRoomActions m_RoomActionsCallbackInterface;
        private readonly InputAction m_Room_Selection;
        private readonly InputAction m_Room_Move;
        private readonly InputAction m_Room_TogglePanel;
        private readonly InputAction m_Room_Remove;
        private readonly InputAction m_Room_Rotate;
        public struct RoomActions
        {
            private @BlueprintInputControls m_Wrapper;
            public RoomActions(@BlueprintInputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Selection => m_Wrapper.m_Room_Selection;
            public InputAction @Move => m_Wrapper.m_Room_Move;
            public InputAction @TogglePanel => m_Wrapper.m_Room_TogglePanel;
            public InputAction @Remove => m_Wrapper.m_Room_Remove;
            public InputAction @Rotate => m_Wrapper.m_Room_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_Room; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RoomActions set) { return set.Get(); }
            public void SetCallbacks(IRoomActions instance)
            {
                if (m_Wrapper.m_RoomActionsCallbackInterface != null)
                {
                    @Selection.started -= m_Wrapper.m_RoomActionsCallbackInterface.OnSelection;
                    @Selection.performed -= m_Wrapper.m_RoomActionsCallbackInterface.OnSelection;
                    @Selection.canceled -= m_Wrapper.m_RoomActionsCallbackInterface.OnSelection;
                    @Move.started -= m_Wrapper.m_RoomActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_RoomActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_RoomActionsCallbackInterface.OnMove;
                    @TogglePanel.started -= m_Wrapper.m_RoomActionsCallbackInterface.OnTogglePanel;
                    @TogglePanel.performed -= m_Wrapper.m_RoomActionsCallbackInterface.OnTogglePanel;
                    @TogglePanel.canceled -= m_Wrapper.m_RoomActionsCallbackInterface.OnTogglePanel;
                    @Remove.started -= m_Wrapper.m_RoomActionsCallbackInterface.OnRemove;
                    @Remove.performed -= m_Wrapper.m_RoomActionsCallbackInterface.OnRemove;
                    @Remove.canceled -= m_Wrapper.m_RoomActionsCallbackInterface.OnRemove;
                    @Rotate.started -= m_Wrapper.m_RoomActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_RoomActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_RoomActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_RoomActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Selection.started += instance.OnSelection;
                    @Selection.performed += instance.OnSelection;
                    @Selection.canceled += instance.OnSelection;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @TogglePanel.started += instance.OnTogglePanel;
                    @TogglePanel.performed += instance.OnTogglePanel;
                    @TogglePanel.canceled += instance.OnTogglePanel;
                    @Remove.started += instance.OnRemove;
                    @Remove.performed += instance.OnRemove;
                    @Remove.canceled += instance.OnRemove;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public RoomActions @Room => new RoomActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface ICameraActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnFloorSliderUp(InputAction.CallbackContext context);
            void OnFloorSliderDown(InputAction.CallbackContext context);
        }
        public interface IRoomActions
        {
            void OnSelection(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnTogglePanel(InputAction.CallbackContext context);
            void OnRemove(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
    }
}
