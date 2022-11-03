using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableCategorySelectInputWorker
    {
        [Inject] private ObjectPlacingUIControls _controls;
        
        private Action<InputAction.CallbackContext> _moveLeft;
        private Action<InputAction.CallbackContext> _moveRight;

        public void Initialize(Action<InputAction.CallbackContext> moveRight, Action<InputAction.CallbackContext> moveLeft)
        {
            _moveLeft = moveLeft;
            _moveRight = moveRight;
            
            _controls.SelectionPanel.CatergoryMoveLeft.performed += _moveLeft;
            _controls.SelectionPanel.CatergoryMoveRight.performed += _moveRight;
            _controls.SelectionPanel.CatergoryMoveLeft.Enable();
            _controls.SelectionPanel.CatergoryMoveRight.Enable();
        }

        public void Dispose()
        {
            _controls.SelectionPanel.CatergoryMoveLeft.performed -= _moveLeft;
            _controls.SelectionPanel.CatergoryMoveRight.performed -= _moveRight;
            _controls.SelectionPanel.CatergoryMoveLeft.Disable();
            _controls.SelectionPanel.CatergoryMoveRight.Disable();
        }
    }
}