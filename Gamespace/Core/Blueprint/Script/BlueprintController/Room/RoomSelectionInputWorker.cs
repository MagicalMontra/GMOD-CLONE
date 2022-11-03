using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class RoomSelectionInputWorker
    {
        [Inject] private BlueprintInputControls _controls;
        private bool _isPressed;
        private Action<Vector2> _selectRoom;
        public void Initialize(Action<Vector2> selectRoom)
        {
            _selectRoom = selectRoom;
            _controls.Room.Selection.started += OnPressed;
            _controls.Room.Selection.canceled += OnReleased;
            _controls.Room.Selection.Enable();
        }
        public void Dispose()
        {
            _selectRoom = null;
            _controls.Room.Selection.started -= OnPressed;
            _controls.Room.Selection.canceled -= OnReleased;
            _controls.Room.Selection.Disable();
        }
        private void OnPressed(InputAction.CallbackContext context)
        {
            _isPressed = true;
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _selectRoom?.Invoke(Mouse.current.position.ReadValue());

            _isPressed = false;
        }
    }

}
