using System;
using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class InteracableInputWorker
    {
        [Inject] private InteractionInputControl _inputControl;
        private Action _checkInteractableAction;
        private bool _isHolding;
        public void Initialize(Action checkInteracbleAction)
        {
            _checkInteractableAction = checkInteracbleAction;
            _inputControl.Interaction.Interact.started += OnToggleInteraction;
            _inputControl.Interaction.Interact.canceled += OnReleaseInteraction;
            _inputControl.Interaction.Interact.Enable();
        }
        public void Dispose()
        {
            _checkInteractableAction = null;
            _inputControl.Interaction.Interact.started -= OnToggleInteraction;
            _inputControl.Interaction.Interact.canceled -= OnReleaseInteraction;
            _inputControl.Interaction.Interact.Disable();
        }
        private void OnToggleInteraction(InputAction.CallbackContext context)
        {
            _isHolding = true;
            _checkInteractableAction?.Invoke();
        }
        private void OnReleaseInteraction(InputAction.CallbackContext context)
        {
            if (_isHolding)
            {
                _checkInteractableAction?.Invoke();
            }

            _isHolding = false;
        }
    }
}
