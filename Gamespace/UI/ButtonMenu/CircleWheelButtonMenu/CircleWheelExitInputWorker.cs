using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelExitInputWorker
    {
        [Inject] private CircleWheelMenuControls _controls;

        private bool _isPress;
        private Action _exitAction;
        public void Initialize(Action exitAction)
        {
            _exitAction = exitAction;
            _controls.UI.Exit.started += OnPress;
            _controls.UI.Exit.canceled += OnRelease;
            _controls.UI.Exit.Enable();
        }
        public void Dispose()
        {
            _exitAction = null;
            _controls.UI.Exit.started -= OnPress;
            _controls.UI.Exit.canceled -= OnRelease;
            _controls.UI.Exit.Disable();
        }

        private void OnPress(InputAction.CallbackContext context)
        {
            _isPress = true;
        }
        private void OnRelease(InputAction.CallbackContext context)
        {
            if (_isPress)
                _exitAction?.Invoke();
            
            _isPress = false;
        }
    }
}