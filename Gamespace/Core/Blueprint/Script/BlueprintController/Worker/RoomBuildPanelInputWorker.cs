using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Gamespace.Core.GameStage;
namespace Gamespace.Core.Blueprint
{
    public class RoomBuildPanelInputWorker
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BlueprintInputControls _controls;
        [Inject] private BlurprintCameraSettings _settings;
        private Action _toggleAction;
        private bool _isObjectMode;
        public void Initialize(Action zoomAction)
        {
            _toggleAction = zoomAction;
            _controls.Room.TogglePanel.started += OnToggle;
            _controls.Room.TogglePanel.Enable();
             _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }
        public void Dispose()
        {
            _toggleAction = null;
            _controls.Room.TogglePanel.started -= OnToggle;
            _controls.Room.TogglePanel.Disable();
        }
              private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play || signal.gameStage == Stage.Object)
            {
                _isObjectMode = true;
                return;
            }
            _isObjectMode = false;
            
        }
        private void OnToggle(InputAction.CallbackContext context)
        {
            if(_isObjectMode)
                return;
                
            _toggleAction?.Invoke();
        }
    }

}
