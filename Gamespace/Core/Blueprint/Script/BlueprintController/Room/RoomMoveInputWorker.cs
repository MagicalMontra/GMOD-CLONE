using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class RoomMoveInputWorker
    {
        public Vector2 deltaPosition => _deltaPosition;
        [Inject] private BlueprintInputControls _controls;
        private Vector2 _deltaPosition;
        public void Initialize()
        {
            _controls.Room.Move.performed += Handle;
            _controls.Room.Move.Enable();
        }
        public void Dispose()
        {
            _controls.Room.Move.performed -= Handle;
            _controls.Room.Move.Disable();
        }
        private void Handle(InputAction.CallbackContext context)
        {
            _deltaPosition = context.ReadValue<Vector2>();
        }
    }

}
