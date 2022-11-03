using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class BlueprintCameraMoveInputWorker : ITickable
    {
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private BlueprintInputControls _controls;

        private Vector2 _inputData;
        private Vector2 _keyboardInput;
        private Action<float, float> _moveAction;
        public void Initialize(Action<float, float> moveAction)
        {
            _moveAction = moveAction;
            _controls.Camera.Move.performed += OnPressed;
            _controls.Camera.Move.canceled += OnReleased;
            _controls.Camera.Move.Enable();
        }
        public void Dispose()
        {
            _moveAction = null;
            _controls.Camera.Move.performed -= OnPressed;
            _controls.Camera.Move.canceled -= OnReleased;
            _controls.Camera.Move.Disable();
        }
        private void OnPressed(InputAction.CallbackContext context)
        {
            _keyboardInput = context.ReadValue<Vector2>();

            if (Mathf.Approximately(_keyboardInput.x, 0.0f))
            {
                _inputData.x = 0.0f;
            }

            if (Mathf.Approximately(_keyboardInput.y, 0.0f))
            {
                _inputData.y = 0.0f;
            }
        }
        private void OnReleased(InputAction.CallbackContext context)
        {
            _inputData = context.ReadValue<Vector2>();
            _keyboardInput = _inputData;
        }
        public void Tick()
        {
            var vector = Vector2.MoveTowards(_inputData, _keyboardInput, Time.deltaTime * _settings.moveSpeed);
            _moveAction?.Invoke(vector.x, vector.y);
        }
    }
}