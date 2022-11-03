using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class ObjectElevateDescendInputWorker
    {
        [Inject] private ObjectElevationControls _controls;

        private bool _hasPowerModifier;
        private Action<float> _elevateAction;

        public void Initialize(Action<float> elevateAction)
        {
            _elevateAction = elevateAction;
            _controls.Elevation.ElevateDescend.performed += Elevation;
            _controls.Elevation.PowerElevateDescendModifier.performed += PowerElevationPerformed;
            _controls.Elevation.PowerElevateDescendModifier.canceled += PowerElevationCanceled;
            _controls.Elevation.ElevateDescend.Enable();
            _controls.Elevation.PowerElevateDescendModifier.Enable();
        }
        public void Dispose()
        {
            _controls.Elevation.ElevateDescend.performed -= Elevation;
            _controls.Elevation.PowerElevateDescendModifier.performed -= PowerElevationPerformed;
            _controls.Elevation.PowerElevateDescendModifier.canceled -= PowerElevationCanceled;
            _controls.Elevation.ElevateDescend.Disable();
            _controls.Elevation.PowerElevateDescendModifier.Disable();
        }
        private void Elevation(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            if (value.y != 0)
            {
                var modifier = _hasPowerModifier ? 1200 : 6000;
                _elevateAction?.Invoke(value.y / modifier);
            }
        }
        private void PowerElevationPerformed(InputAction.CallbackContext context)
        {
            _hasPowerModifier = true;
        }
        private void PowerElevationCanceled(InputAction.CallbackContext context)
        {
            _hasPowerModifier = false;
        }
    }
}