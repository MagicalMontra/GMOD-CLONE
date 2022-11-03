using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPlaceExitInputWorker
    {
        [Inject] private ObjectPlacingControls _objectPlacingControls;

        private Action<InputAction.CallbackContext> _exitAction;

        public void Initialize(Action<InputAction.CallbackContext> exitAction)
        {
            _exitAction = exitAction;
            _objectPlacingControls.ObjectPlacing.Exit.performed += _exitAction;
            _objectPlacingControls.ObjectPlacing.Exit.Enable();
        }
        public void Dispose()
        {
            _objectPlacingControls.ObjectPlacing.Exit.performed -= _exitAction;
            _objectPlacingControls.ObjectPlacing.Exit.Disable();
        }
    }
}