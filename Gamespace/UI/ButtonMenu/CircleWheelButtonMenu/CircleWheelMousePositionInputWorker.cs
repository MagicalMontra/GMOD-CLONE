using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelMousePositionInputWorker
    {
        public Vector3 position => _position;

        [Inject] private CircleWheelMenuControls _controls;

        private Vector2 _position;

        public void Initialize()
        {
            _controls.UI.MousePosition.performed += MousePerformed;
            _controls.UI.MousePosition.Enable();
        }
        public void Dispose()
        {
            _controls.UI.MousePosition.performed -= MousePerformed;
            _controls.UI.MousePosition.Disable();
        }
        private void MousePerformed(InputAction.CallbackContext context)
        {
            _position = context.ReadValue<Vector2>();
        }
    }
}