using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationResetInputWorker
    {
        [Inject] private ObjectRotateControls _controls;

        private Action _resetAction;

        public void Initialize(Action resetAction)
        {
            _resetAction = resetAction;
            _controls.Other.Reset.performed += Reset;
            _controls.Other.Reset.Enable();
        }
        public void Dispose()
        {
            _controls.Other.Reset.performed -= Reset;
            _controls.Other.Reset.Disable();
        }
        private void Reset(InputAction.CallbackContext context)
        {
            _resetAction.Invoke();
        }
    }
}