using UnityEngine;
using System;
using UnityEngine.InputSystem;
using Zenject;
using Gamespace.Core.GameStage;
namespace Gamespace.Core.Blueprint
{
    public class BlueprintCameraZoomInputWorker
    {
        [Inject] private BlueprintInputControls _controls;
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private SignalBus _signalBus;
        private Action<float> _zoomAction;
        private float _zoomValue;

        private bool _isObjectMode;
        public void Initialize(Action<float> zoomAction)
        {
            _zoomAction = zoomAction;
            _controls.Camera.Zoom.performed += OnScroll;
            _controls.Camera.Zoom.Enable();
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
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

        public void Dispose()
        {
            _zoomAction = null;
            _controls.Camera.Zoom.performed -= OnScroll;
            _controls.Camera.Zoom.Disable();
        }
        private void OnScroll(InputAction.CallbackContext context)
        {
            if(_isObjectMode)
                return;
            _zoomValue = context.ReadValue<float>();
            _zoomAction?.Invoke(_zoomValue * _settings.zoomSpeed * Time.deltaTime);
        }

    }

}
