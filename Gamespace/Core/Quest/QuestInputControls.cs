// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/Quest/QuestInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.Quest
{
    public class @QuestInputControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @QuestInputControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""QuestInputControls"",
    ""maps"": [
        {
            ""name"": ""Quest"",
            ""id"": ""cdaf2cc1-114b-4efa-9acc-5858f517525c"",
            ""actions"": [
                {
                    ""name"": ""OpenQuest"",
                    ""type"": ""Button"",
                    ""id"": ""b6d64dc3-37a6-4d49-afca-1875dab25271"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CloseQuest"",
                    ""type"": ""Button"",
                    ""id"": ""72e6c653-ed9a-4f34-9859-362d8c056c7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0cd51dc5-bc5c-4fec-bdba-6f3cad541cb9"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenQuest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b51874-c2bc-4c6a-b78d-e76096901854"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseQuest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Quest
            m_Quest = asset.FindActionMap("Quest", throwIfNotFound: true);
            m_Quest_OpenQuest = m_Quest.FindAction("OpenQuest", throwIfNotFound: true);
            m_Quest_CloseQuest = m_Quest.FindAction("CloseQuest", throwIfNotFound: true);
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

        // Quest
        private readonly InputActionMap m_Quest;
        private IQuestActions m_QuestActionsCallbackInterface;
        private readonly InputAction m_Quest_OpenQuest;
        private readonly InputAction m_Quest_CloseQuest;
        public struct QuestActions
        {
            private @QuestInputControls m_Wrapper;
            public QuestActions(@QuestInputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @OpenQuest => m_Wrapper.m_Quest_OpenQuest;
            public InputAction @CloseQuest => m_Wrapper.m_Quest_CloseQuest;
            public InputActionMap Get() { return m_Wrapper.m_Quest; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(QuestActions set) { return set.Get(); }
            public void SetCallbacks(IQuestActions instance)
            {
                if (m_Wrapper.m_QuestActionsCallbackInterface != null)
                {
                    @OpenQuest.started -= m_Wrapper.m_QuestActionsCallbackInterface.OnOpenQuest;
                    @OpenQuest.performed -= m_Wrapper.m_QuestActionsCallbackInterface.OnOpenQuest;
                    @OpenQuest.canceled -= m_Wrapper.m_QuestActionsCallbackInterface.OnOpenQuest;
                    @CloseQuest.started -= m_Wrapper.m_QuestActionsCallbackInterface.OnCloseQuest;
                    @CloseQuest.performed -= m_Wrapper.m_QuestActionsCallbackInterface.OnCloseQuest;
                    @CloseQuest.canceled -= m_Wrapper.m_QuestActionsCallbackInterface.OnCloseQuest;
                }
                m_Wrapper.m_QuestActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @OpenQuest.started += instance.OnOpenQuest;
                    @OpenQuest.performed += instance.OnOpenQuest;
                    @OpenQuest.canceled += instance.OnOpenQuest;
                    @CloseQuest.started += instance.OnCloseQuest;
                    @CloseQuest.performed += instance.OnCloseQuest;
                    @CloseQuest.canceled += instance.OnCloseQuest;
                }
            }
        }
        public QuestActions @Quest => new QuestActions(this);
        public interface IQuestActions
        {
            void OnOpenQuest(InputAction.CallbackContext context);
            void OnCloseQuest(InputAction.CallbackContext context);
        }
    }
}
