using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.InputSystem;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomRemoveInputWorker 
    {
        [Inject] private BlueprintInputControls _controls;
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private RoomController _roomController;
        private Action _removeRoomAction;
        
        public void Initialize(Action zoomAction)
        {
            _removeRoomAction = zoomAction;
            _controls.Room.Remove.started += OnToggle;
            _controls.Room.Remove.Enable();
        }
        public void Dispose()
        {
            _removeRoomAction = null;
            _controls.Room.Remove.started -= OnToggle;
            _controls.Room.Remove.Disable();
        }
        private void OnToggle(InputAction.CallbackContext context)
        {
            if (_roomController.currentRoom)
            {
                _removeRoomAction?.Invoke();
            }  
        }
    }

}
