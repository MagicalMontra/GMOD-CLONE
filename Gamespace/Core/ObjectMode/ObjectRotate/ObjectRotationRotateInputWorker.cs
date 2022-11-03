using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationRotateInputWorker : ITickable
    {
        [Inject] private ObjectRotateControls _controls;
        
        private float _value;
        private bool _isPressed;
        private Action<float> _rotateAction;
        
        public void Initialize(Action<float> rotateAction)
        {
            if (_controls.Rotate.Get().actions.Count < 0)
                return;

            _rotateAction = rotateAction;

            for (int i = 0; i < _controls.Rotate.Get().actions.Count; i++)
            {
                _controls.Rotate.Get().actions[i].performed += SetActive;
                _controls.Rotate.Get().actions[i].canceled += SetActive;
            }
        }
        public void Dispose()
        {
            for (int i = 0; i < _controls.Rotate.Get().actions.Count; i++)
            {
                _controls.Rotate.Get().actions[i].performed -= SetActive;
                _controls.Rotate.Get().actions[i].canceled -= SetActive;
            }
            _rotateAction = null;
        }
        private void SetActive(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            _isPressed = value != 0;
            _value = value;
        }
        public void Tick()
        {
            if (!_isPressed)
                return;
            
            _rotateAction?.Invoke(_value);
        }
    }
}