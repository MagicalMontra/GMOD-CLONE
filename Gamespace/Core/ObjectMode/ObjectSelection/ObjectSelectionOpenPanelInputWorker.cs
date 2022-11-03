using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionOpenPanelInputWorker
    {
        [Inject] private ObjectSelectionControls _controls;

        private bool _isPressed;
        private Action _openAction;
        
        public void Initialize(Action openAction)
        {
            _openAction = openAction;
            _controls.Panel.Open.started += OnPressed;
            _controls.Panel.Open.canceled += OnReleased;
            _controls.Panel.Open.Enable();
        }
        public void Dispose()
        {
            _openAction = null;
            _controls.Panel.Open.started -= OnPressed;
            _controls.Panel.Open.canceled -= OnReleased;
            _controls.Panel.Open.Disable();
        }
        private void OnPressed(InputAction.CallbackContext context)
        {
            _isPressed = true;
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _openAction?.Invoke();

            _isPressed = false;
        }
    }
}