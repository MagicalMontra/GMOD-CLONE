using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationAxisSwitchInputWorker
    {
        [Inject] private ObjectRotateControls _controls;
        
        private int _rotateIndex;
        private Action<int> _switchAction;
        private InputAction _selectedAction;
        public void Initialize(Action<int> switchAction)
        {
            _switchAction = switchAction;
            _controls.Other.Switch.performed += Switch;
            _controls.Other.Switch.Enable();
            
            if (_controls.Rotate.Get().actions.Count < 0)
                return;
            
            _selectedAction = _controls.Rotate.Get().actions[_rotateIndex];
            SetInputEnable(true, _selectedAction);
        }
        public void Dispose()
        {
            _controls.Other.Switch.performed -= Switch;
            _controls.Other.Switch.Disable();

            for (int i = 0; i < _controls.Rotate.Get().actions.Count; i++)
                SetInputEnable(false, _controls.Rotate.Get().actions[i]);

            _switchAction = null;
        }
        private void Switch(InputAction.CallbackContext context)
        {
            if (_rotateIndex + 1 > _controls.Rotate.Get().actions.Count - 1)
                _rotateIndex = 0;
            else
                _rotateIndex++;

            _switchAction.Invoke(_rotateIndex);
            SetInputEnable(false, _selectedAction);
            _selectedAction = _controls.Rotate.Get().actions[_rotateIndex];
            SetInputEnable(true, _selectedAction);
        }
        private void SetInputEnable(bool enabled, InputAction action)
        {
            if (enabled)
                action.Enable();
            else
                action.Disable();
        }
    }
}