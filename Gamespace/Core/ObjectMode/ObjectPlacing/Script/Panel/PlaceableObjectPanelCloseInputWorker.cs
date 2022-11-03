using System;
using Gamespace.Utilis;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectPanelCloseInputWorker : InputWorker
    {
        [Inject] private ObjectPlacingUIControls _controls;
        public override void Initialize(Action action)
        {
            _action = action;
            _controls.SelectionPanel.Close.started += OnPressed;
            _controls.SelectionPanel.Close.canceled += OnReleased;
            _controls.SelectionPanel.Close.Enable();
        }
        public override void Dispose()
        {
            _controls.SelectionPanel.Close.started -= OnPressed;
            _controls.SelectionPanel.Close.canceled -= OnReleased;
            _controls.SelectionPanel.Close.Disable();
        }
    }
}