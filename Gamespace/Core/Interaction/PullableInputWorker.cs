using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class PullableInputWorker : ITickable
    {
        [Inject] private InteractionInputControl _inputControl;
        private Action<float> _pullableAction;

        private float _moveValue;
        public void Initialize(Action<float> pullableAction)
        {
            _pullableAction = pullableAction;
            _inputControl.Interaction.Pulling.performed += OnTogglePull;
            _inputControl.Interaction.Pulling.canceled += OnReleasePull;
            _inputControl.Interaction.Pulling.Enable();
        }
        public void Dispose()
        {
            _pullableAction = null;
            _inputControl.Interaction.Pulling.performed -= OnTogglePull;
            _inputControl.Interaction.Pulling.canceled -= OnReleasePull;
            _inputControl.Interaction.Pulling.Disable();
        }
        private void OnTogglePull(InputAction.CallbackContext context)
        {
            _moveValue = context.ReadValue<float>();
            _pullableAction?.Invoke(_moveValue);
        }
        private void OnReleasePull(InputAction.CallbackContext context)
        {
            _moveValue = 0;
            _pullableAction?.Invoke(_moveValue);
        }
        public void Tick()
        {
            // _pullableAction?.Invoke(_moveValue);
        }
    }
}