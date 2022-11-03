using System;
using Gamespace.Utilis;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionPropertyExitInputWorker : InputWorker
    {
        [Inject] private ActionInputControls _controls;
        
        public override void Initialize(Action action)
        {
            _action = action;
            _controls.Property.Exit.started += OnPressed;
            _controls.Property.Exit.canceled += OnReleased;
            _controls.Property.Exit.Enable();
        }
        public override void Dispose()
        {
            _controls.Property.Exit.started -= OnPressed;
            _controls.Property.Exit.canceled -= OnReleased;
            _controls.Property.Exit.Disable();
            _action = null;
        }
    }
}