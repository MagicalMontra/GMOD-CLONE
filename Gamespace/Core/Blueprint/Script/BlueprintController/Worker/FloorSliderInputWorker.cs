using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Gamespace.Core.GameStage;
namespace Gamespace.Core.Blueprint
{
    public class FloorSliderInputWorker : IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BlueprintInputControls _controls;
        private float _keyboardInput;
        private bool _isObjectMode;
        private Action<float> _toggelSliderAction;

          private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play || signal.gameStage == Stage.Object)
            {
                _isObjectMode = true;
                return;
            }
            _isObjectMode = false;
            
        }
        public void Initialize(Action<float> action)
        {
            _toggelSliderAction = action;
            _controls.Camera.FloorSliderUp.started += OnPressedUp;
            _controls.Camera.FloorSliderUp.Enable();
            _controls.Camera.FloorSliderDown.started += OnPressedDown;
            _controls.Camera.FloorSliderDown.Enable();
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }
        public void Dispose()
        {
            _toggelSliderAction = null;
            _controls.Camera.FloorSliderUp.started -= OnPressedUp;
            _controls.Camera.FloorSliderUp.Disable();
            _controls.Camera.FloorSliderDown.started -= OnPressedDown;
            _controls.Camera.FloorSliderDown.Disable();
        }
        private void OnPressedUp(InputAction.CallbackContext context)
        {
            if(_isObjectMode)
                return;

            _keyboardInput = 1;
            _toggelSliderAction?.Invoke(_keyboardInput);

        }
        private void OnPressedDown(InputAction.CallbackContext context)
        {
            if(_isObjectMode)
                return;
                
            _keyboardInput = 0;
            _toggelSliderAction?.Invoke(_keyboardInput);
        }


        public void Initialize()
        {
            Debug.Log("D");
        }
    }

}
