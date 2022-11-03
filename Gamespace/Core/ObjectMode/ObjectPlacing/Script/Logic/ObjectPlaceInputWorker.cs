using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPlaceInputWorker
    {
        [Inject] private ObjectPlacingControls _objectPlacingControls;

        private Action _placeAction;

        public void Initialize(Action placeAction)
        {
            _placeAction = placeAction;
            _objectPlacingControls.ObjectPlacing.Place.performed += Place;
            _objectPlacingControls.ObjectPlacing.Place.Enable();
        }
        public void Dispose()
        {
            _objectPlacingControls.ObjectPlacing.Place.performed -= Place;
            _objectPlacingControls.ObjectPlacing.Place.Disable();
        }

        private void Place(InputAction.CallbackContext context)
        {
            _placeAction?.Invoke();
        }
    }
}