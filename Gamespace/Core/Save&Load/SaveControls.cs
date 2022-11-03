// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/Save&Load/SaveControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.Save
{
    public class @SaveControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SaveControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SaveControls"",
    ""maps"": [
        {
            ""name"": ""Save"",
            ""id"": ""87672107-05ad-488b-9821-5b656104ff90"",
            ""actions"": [
                {
                    ""name"": ""SaveButton"",
                    ""type"": ""Button"",
                    ""id"": ""ba80111a-d612-494f-b61c-47db6bbb8061"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b385578-15b1-4170-98d1-3dfbd1300cb1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaveButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Save
            m_Save = asset.FindActionMap("Save", throwIfNotFound: true);
            m_Save_SaveButton = m_Save.FindAction("SaveButton", throwIfNotFound: true);
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

        // Save
        private readonly InputActionMap m_Save;
        private ISaveActions m_SaveActionsCallbackInterface;
        private readonly InputAction m_Save_SaveButton;
        public struct SaveActions
        {
            private @SaveControls m_Wrapper;
            public SaveActions(@SaveControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @SaveButton => m_Wrapper.m_Save_SaveButton;
            public InputActionMap Get() { return m_Wrapper.m_Save; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SaveActions set) { return set.Get(); }
            public void SetCallbacks(ISaveActions instance)
            {
                if (m_Wrapper.m_SaveActionsCallbackInterface != null)
                {
                    @SaveButton.started -= m_Wrapper.m_SaveActionsCallbackInterface.OnSaveButton;
                    @SaveButton.performed -= m_Wrapper.m_SaveActionsCallbackInterface.OnSaveButton;
                    @SaveButton.canceled -= m_Wrapper.m_SaveActionsCallbackInterface.OnSaveButton;
                }
                m_Wrapper.m_SaveActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SaveButton.started += instance.OnSaveButton;
                    @SaveButton.performed += instance.OnSaveButton;
                    @SaveButton.canceled += instance.OnSaveButton;
                }
            }
        }
        public SaveActions @Save => new SaveActions(this);
        public interface ISaveActions
        {
            void OnSaveButton(InputAction.CallbackContext context);
        }
    }
}
