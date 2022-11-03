// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Interacable/InteractionInputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.Interaction
{
    public class @InteractionInputControl : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InteractionInputControl()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InteractionInputControl"",
    ""maps"": [
        {
            ""name"": ""Interaction"",
            ""id"": ""c556830e-087b-4494-a217-20cc6d055a00"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5fc0292a-abca-47cf-95a2-374e34766ba5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pulling"",
                    ""type"": ""Value"",
                    ""id"": ""48c11654-513d-447a-9291-49d2544c2002"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db4604bc-268e-4791-b3ca-f0dbce1119d7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e033b68a-665d-4e2e-b6e5-4aa69466881f"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pulling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Interaction
            m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
            m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
            m_Interaction_Pulling = m_Interaction.FindAction("Pulling", throwIfNotFound: true);
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

        // Interaction
        private readonly InputActionMap m_Interaction;
        private IInteractionActions m_InteractionActionsCallbackInterface;
        private readonly InputAction m_Interaction_Interact;
        private readonly InputAction m_Interaction_Pulling;
        public struct InteractionActions
        {
            private @InteractionInputControl m_Wrapper;
            public InteractionActions(@InteractionInputControl wrapper) { m_Wrapper = wrapper; }
            public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
            public InputAction @Pulling => m_Wrapper.m_Interaction_Pulling;
            public InputActionMap Get() { return m_Wrapper.m_Interaction; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
            public void SetCallbacks(IInteractionActions instance)
            {
                if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
                {
                    @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Pulling.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPulling;
                    @Pulling.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPulling;
                    @Pulling.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPulling;
                }
                m_Wrapper.m_InteractionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Pulling.started += instance.OnPulling;
                    @Pulling.performed += instance.OnPulling;
                    @Pulling.canceled += instance.OnPulling;
                }
            }
        }
        public InteractionActions @Interaction => new InteractionActions(this);
        public interface IInteractionActions
        {
            void OnInteract(InputAction.CallbackContext context);
            void OnPulling(InputAction.CallbackContext context);
        }
    }
}
