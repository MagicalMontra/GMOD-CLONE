// GENERATED AUTOMATICALLY FROM 'Assets/Gamespace/Core/Actions/ActionInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gamespace.Core.Actions
{
    public class @ActionInputControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ActionInputControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionInputControls"",
    ""maps"": [
        {
            ""name"": ""Link"",
            ""id"": ""ac1e3033-9a4b-407a-a9a5-43a63580442e"",
            ""actions"": [
                {
                    ""name"": ""Commit"",
                    ""type"": ""Button"",
                    ""id"": ""f141ed6e-7300-43a2-9b35-7bddf7c6bda5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""8f51ca59-16e7-4eef-a201-697d6af8d1a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83503e3c-ea09-4334-956a-a997b5f446c3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Commit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""598738df-3b50-4548-b684-ea3915537e84"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Property"",
            ""id"": ""fbc1885b-c365-4b2c-a05d-067d07cbc608"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""6a6e42a6-b334-4ff7-a5a9-e2033214868a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextPage"",
                    ""type"": ""Button"",
                    ""id"": ""9c7bd264-2028-47ec-ab89-dc732046159a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackPage"",
                    ""type"": ""Button"",
                    ""id"": ""64d0c7f3-b889-400a-a81c-a32dbafdeac1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PageControls"",
                    ""type"": ""Button"",
                    ""id"": ""14afc479-99dd-4ca3-8ed6-974875301f30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""348d486e-f4cc-46c6-9b1c-ca7efc480fc5"",
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
                    ""id"": ""9d3d38e5-fefb-444c-8674-fe46f60d523f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""NextPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffc0649c-75c4-4cc2-9d84-eee7a8f2a9be"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""BackPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8d27ec5b-5837-4714-a2fb-42909e4099ad"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PageControls"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dc171431-c103-4466-b5f9-8d687512fb10"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PageControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7f0b46af-92ea-4469-b72b-dc4d4fa8df49"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PageControls"",
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
        }
    ]
}");
            // Link
            m_Link = asset.FindActionMap("Link", throwIfNotFound: true);
            m_Link_Commit = m_Link.FindAction("Commit", throwIfNotFound: true);
            m_Link_Cancel = m_Link.FindAction("Cancel", throwIfNotFound: true);
            // Property
            m_Property = asset.FindActionMap("Property", throwIfNotFound: true);
            m_Property_Exit = m_Property.FindAction("Exit", throwIfNotFound: true);
            m_Property_NextPage = m_Property.FindAction("NextPage", throwIfNotFound: true);
            m_Property_BackPage = m_Property.FindAction("BackPage", throwIfNotFound: true);
            m_Property_PageControls = m_Property.FindAction("PageControls", throwIfNotFound: true);
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

        // Link
        private readonly InputActionMap m_Link;
        private ILinkActions m_LinkActionsCallbackInterface;
        private readonly InputAction m_Link_Commit;
        private readonly InputAction m_Link_Cancel;
        public struct LinkActions
        {
            private @ActionInputControls m_Wrapper;
            public LinkActions(@ActionInputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Commit => m_Wrapper.m_Link_Commit;
            public InputAction @Cancel => m_Wrapper.m_Link_Cancel;
            public InputActionMap Get() { return m_Wrapper.m_Link; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LinkActions set) { return set.Get(); }
            public void SetCallbacks(ILinkActions instance)
            {
                if (m_Wrapper.m_LinkActionsCallbackInterface != null)
                {
                    @Commit.started -= m_Wrapper.m_LinkActionsCallbackInterface.OnCommit;
                    @Commit.performed -= m_Wrapper.m_LinkActionsCallbackInterface.OnCommit;
                    @Commit.canceled -= m_Wrapper.m_LinkActionsCallbackInterface.OnCommit;
                    @Cancel.started -= m_Wrapper.m_LinkActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_LinkActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_LinkActionsCallbackInterface.OnCancel;
                }
                m_Wrapper.m_LinkActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Commit.started += instance.OnCommit;
                    @Commit.performed += instance.OnCommit;
                    @Commit.canceled += instance.OnCommit;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                }
            }
        }
        public LinkActions @Link => new LinkActions(this);

        // Property
        private readonly InputActionMap m_Property;
        private IPropertyActions m_PropertyActionsCallbackInterface;
        private readonly InputAction m_Property_Exit;
        private readonly InputAction m_Property_NextPage;
        private readonly InputAction m_Property_BackPage;
        private readonly InputAction m_Property_PageControls;
        public struct PropertyActions
        {
            private @ActionInputControls m_Wrapper;
            public PropertyActions(@ActionInputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Exit => m_Wrapper.m_Property_Exit;
            public InputAction @NextPage => m_Wrapper.m_Property_NextPage;
            public InputAction @BackPage => m_Wrapper.m_Property_BackPage;
            public InputAction @PageControls => m_Wrapper.m_Property_PageControls;
            public InputActionMap Get() { return m_Wrapper.m_Property; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PropertyActions set) { return set.Get(); }
            public void SetCallbacks(IPropertyActions instance)
            {
                if (m_Wrapper.m_PropertyActionsCallbackInterface != null)
                {
                    @Exit.started -= m_Wrapper.m_PropertyActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_PropertyActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_PropertyActionsCallbackInterface.OnExit;
                    @NextPage.started -= m_Wrapper.m_PropertyActionsCallbackInterface.OnNextPage;
                    @NextPage.performed -= m_Wrapper.m_PropertyActionsCallbackInterface.OnNextPage;
                    @NextPage.canceled -= m_Wrapper.m_PropertyActionsCallbackInterface.OnNextPage;
                    @BackPage.started -= m_Wrapper.m_PropertyActionsCallbackInterface.OnBackPage;
                    @BackPage.performed -= m_Wrapper.m_PropertyActionsCallbackInterface.OnBackPage;
                    @BackPage.canceled -= m_Wrapper.m_PropertyActionsCallbackInterface.OnBackPage;
                    @PageControls.started -= m_Wrapper.m_PropertyActionsCallbackInterface.OnPageControls;
                    @PageControls.performed -= m_Wrapper.m_PropertyActionsCallbackInterface.OnPageControls;
                    @PageControls.canceled -= m_Wrapper.m_PropertyActionsCallbackInterface.OnPageControls;
                }
                m_Wrapper.m_PropertyActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                    @NextPage.started += instance.OnNextPage;
                    @NextPage.performed += instance.OnNextPage;
                    @NextPage.canceled += instance.OnNextPage;
                    @BackPage.started += instance.OnBackPage;
                    @BackPage.performed += instance.OnBackPage;
                    @BackPage.canceled += instance.OnBackPage;
                    @PageControls.started += instance.OnPageControls;
                    @PageControls.performed += instance.OnPageControls;
                    @PageControls.canceled += instance.OnPageControls;
                }
            }
        }
        public PropertyActions @Property => new PropertyActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface ILinkActions
        {
            void OnCommit(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
        }
        public interface IPropertyActions
        {
            void OnExit(InputAction.CallbackContext context);
            void OnNextPage(InputAction.CallbackContext context);
            void OnBackPage(InputAction.CallbackContext context);
            void OnPageControls(InputAction.CallbackContext context);
        }
    }
}
