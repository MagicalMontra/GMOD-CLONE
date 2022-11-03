using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationExitInputWorker
    {
        [Inject] private ObjectRotateControls _controls;

        private Action _exitAction;

        public void Initialize(Action exitAction)
        {
            _exitAction = exitAction;
            _controls.Other.Exit.performed += Exit;
            _controls.Other.Exit.Enable();
        }
        public void Dispose()
        {
            _controls.Other.Exit.performed -= Exit;
            _controls.Other.Exit.Disable();
        }
        private void Exit(InputAction.CallbackContext context)
        {
            _exitAction.Invoke();
        }
    }
}