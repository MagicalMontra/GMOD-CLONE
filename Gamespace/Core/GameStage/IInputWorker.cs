using System;
using UnityEngine.InputSystem;

namespace Gamespace.Utilis
{
    public interface IInputWorker
    {
        void Initialize(Action action);
        void Dispose();
    }

    public abstract class InputWorker : IInputWorker
    {
        protected Action _action;
        
        private bool _isPressed;

        public abstract void Initialize(Action action);
        public abstract void Dispose();
        
        protected virtual void OnPressed(InputAction.CallbackContext context)
        {
            _isPressed = true;
        }
        protected virtual void OnReleased(InputAction.CallbackContext context)
        {
            if (_isPressed)
                _action?.Invoke();

            _isPressed = false;
        }
    }
}