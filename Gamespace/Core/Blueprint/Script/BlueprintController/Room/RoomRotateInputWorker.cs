using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.InputSystem;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomRotateInputWorker 
    {

        [Inject] private BlueprintInputControls _controls;
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private RoomController _roomController;
        private Action _rotateRoomAction;
        
        public void Initialize(Action rotateAction)
        {
            _rotateRoomAction = rotateAction;
            _controls.Room.Rotate.started += OnToggle;
            _controls.Room.Rotate.Enable();
        }
        public void Dispose()
        {
            _rotateRoomAction = null;
            _controls.Room.Rotate.started -= OnToggle;
            _controls.Room.Rotate.Disable();
        }
        private void OnToggle(InputAction.CallbackContext context)
        {
            if (_roomController.currentRoom)
            {
                _rotateRoomAction?.Invoke();
            }
        }
    }

}
