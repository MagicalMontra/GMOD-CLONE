// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/GameStage/GameStageKeyMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.GameStage
{
    public class @GameStageKeyMap : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameStageKeyMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameStageKeyMap"",
    ""maps"": [
        {
            ""name"": ""Editor"",
            ""id"": ""3036c263-ae80-412b-a36d-a5fda5b79429"",
            ""actions"": [
                {
                    ""name"": ""PlayMode"",
                    ""type"": ""Button"",
                    ""id"": ""0ba530d0-cb7b-45b7-b528-b6b560894da4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchEditorMode"",
                    ""type"": ""Button"",
                    ""id"": ""aff55a5f-96d0-467c-a16b-973180057420"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf80235b-8032-4e67-8953-1fa6d4e9f9c2"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1663b1e8-90aa-473b-bfe7-1857cbdf4bcc"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchEditorMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Editor
            m_Editor = asset.FindActionMap("Editor", throwIfNotFound: true);
            m_Editor_PlayMode = m_Editor.FindAction("PlayMode", throwIfNotFound: true);
            m_Editor_SwitchEditorMode = m_Editor.FindAction("SwitchEditorMode", throwIfNotFound: true);
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

        // Editor
        private readonly InputActionMap m_Editor;
        private IEditorActions m_EditorActionsCallbackInterface;
        private readonly InputAction m_Editor_PlayMode;
        private readonly InputAction m_Editor_SwitchEditorMode;
        public struct EditorActions
        {
            private @GameStageKeyMap m_Wrapper;
            public EditorActions(@GameStageKeyMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @PlayMode => m_Wrapper.m_Editor_PlayMode;
            public InputAction @SwitchEditorMode => m_Wrapper.m_Editor_SwitchEditorMode;
            public InputActionMap Get() { return m_Wrapper.m_Editor; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(EditorActions set) { return set.Get(); }
            public void SetCallbacks(IEditorActions instance)
            {
                if (m_Wrapper.m_EditorActionsCallbackInterface != null)
                {
                    @PlayMode.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnPlayMode;
                    @PlayMode.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnPlayMode;
                    @PlayMode.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnPlayMode;
                    @SwitchEditorMode.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnSwitchEditorMode;
                    @SwitchEditorMode.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnSwitchEditorMode;
                    @SwitchEditorMode.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnSwitchEditorMode;
                }
                m_Wrapper.m_EditorActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PlayMode.started += instance.OnPlayMode;
                    @PlayMode.performed += instance.OnPlayMode;
                    @PlayMode.canceled += instance.OnPlayMode;
                    @SwitchEditorMode.started += instance.OnSwitchEditorMode;
                    @SwitchEditorMode.performed += instance.OnSwitchEditorMode;
                    @SwitchEditorMode.canceled += instance.OnSwitchEditorMode;
                }
            }
        }
        public EditorActions @Editor => new EditorActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IEditorActions
        {
            void OnPlayMode(InputAction.CallbackContext context);
            void OnSwitchEditorMode(InputAction.CallbackContext context);
        }
    }
}
