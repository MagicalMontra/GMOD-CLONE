
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelPageChangeInputWorker
    {
        [Inject] private CircleWheelMenuControls _controls;

        private int _value;
        private bool _isPressed;
        private Action<int> _executeAction;
        
        public void Initialize(Action<int> executeAction)
        {
            _executeAction = executeAction;
            _controls.UI.PageChange.started += OnPress;
            _controls.UI.PageChange.canceled += OnReleased;
            _controls.UI.PageChange.Enable();
        }
        public void Dispose()
        {
            _executeAction = null;
            _controls.UI.PageChange.started -= OnPress;
            _controls.UI.PageChange.canceled -= OnReleased;
            _controls.UI.PageChange.Disable();
        }
        private void OnPress(InputAction.CallbackContext context)
        {
            _isPressed = true;
            _value = (int)context.ReadValue<float>();
            var modifier = _value < 0 ? -1 : 1;
            _value /= _value * modifier;
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _executeAction.Invoke(_value);
            
            _isPressed = false;
        }
    }
}