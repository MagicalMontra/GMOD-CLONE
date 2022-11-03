using System;
using UnityEngine.InputSystem;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class PullableMouseInputWorker
    {
        [Inject] private InteractionInputControl _inputControl;
        private Action<float> _pullingAction;
        public void Initialize(Action<float> pullingAction)
        {
            _pullingAction = pullingAction;
            _inputControl.Interaction.Interact.performed += OnPullingInteraction;
            _inputControl.Interaction.Interact.Enable();
        }
        public void Dispose()
        {
            _pullingAction = null;
            _inputControl.Interaction.Interact.performed -= OnPullingInteraction;
            _inputControl.Interaction.Interact.Disable();
        }
        private void OnPullingInteraction(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            _pullingAction?.Invoke(value);
        }
    
    }

}
