using System;
using Gamespace.Utilis;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectPanelOpenInputWorker : InputWorker
    {
        [Inject] private ObjectPlacingUIControls _controls;
        public override void Initialize(Action action)
        {
            _action = action;
            _controls.SelectionPanel.Open.started += OnPressed;
            _controls.SelectionPanel.Open.canceled += OnReleased;
            _controls.SelectionPanel.Open.Enable();
        }
        public override void Dispose()
        {
            _controls.SelectionPanel.Open.started -= OnPressed;
            _controls.SelectionPanel.Open.canceled -= OnReleased;
            _controls.SelectionPanel.Open.Disable();
        }
    }
}