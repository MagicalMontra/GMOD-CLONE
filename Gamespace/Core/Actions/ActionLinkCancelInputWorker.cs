using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionLinkCancelInputWorker
    {
        [Inject] private ActionInputControls _controls;

        private Action _linkCancelAction;

        public void Initialize(Action linkCancelAction)
        {
            _linkCancelAction = linkCancelAction;
            _controls.Link.Cancel.performed += LinkCancel;
            _controls.Link.Cancel.Enable();
        }
        public void Dispose()
        {
            _linkCancelAction = null;
            _controls.Link.Cancel.performed -= LinkCancel;
            _controls.Link.Cancel.Disable();
        }
        private void LinkCancel(InputAction.CallbackContext context)
        {
            _linkCancelAction?.Invoke();
        }
    }
}