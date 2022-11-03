using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelMouseExecuteInputWorker
    {
        public bool isPressed => _isPressed;
        
        [Inject] private CircleWheelMenuControls _controls;

        private bool _isPressed;
        private Action _executeAction;
        public void Initialize(Action executeAction)
        {
            _executeAction = executeAction;
            _controls.UI.Execute.started += OnPressed;
            _controls.UI.Execute.canceled += OnReleased;
            _controls.UI.Execute.Enable();
        }
        public void Dispose()
        {
            _executeAction = null;
            _controls.UI.Execute.started -= OnPressed;
            _controls.UI.Execute.canceled -= OnReleased;
            _controls.UI.Execute.Disable();
        }
        private void OnPressed(InputAction.CallbackContext context)
        {
            _isPressed = true;
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _executeAction?.Invoke();
                
            _isPressed = false;
        }
    }
}