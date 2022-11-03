using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionLinkCommitInputWorker
    {
        [Inject] private ActionInputControls _controls;

        private bool _isPressed;
        private Action _linkAction;

        public void Initialize(Action linkAction)
        {
            _linkAction = linkAction;
            _controls.Link.Commit.started += OnPressed;
            _controls.Link.Commit.canceled += OnReleased;
            _controls.Link.Commit.Enable();
        }
        public void Dispose()
        {
            _linkAction = null;
            _controls.Link.Commit.started += OnPressed;
            _controls.Link.Commit.canceled += OnReleased;
            _controls.Link.Commit.Disable();
        }
        private void OnPressed(InputAction.CallbackContext context)
        {
            _isPressed = true;
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _linkAction?.Invoke();

            _isPressed = false;
        }
    }
}