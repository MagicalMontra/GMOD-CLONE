using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Save
{
    public class SaveInputWorker
    {
            [Inject] private SaveControls _controls;
    
            private Action _toggleSavePanel;
            public void Initialize(Action rotateAction)
            {
                _toggleSavePanel = rotateAction;
                _controls.Save.SaveButton.performed += OnToggle;
                _controls.Save.SaveButton.Enable();
            }
            public void Dispose()
            {
                _toggleSavePanel = null;
                _controls.Save.SaveButton.performed -= OnToggle;
                _controls.Save.SaveButton.Disable();
            }
            private void OnToggle(InputAction.CallbackContext context)
            {
                    _toggleSavePanel?.Invoke();
            }
    }
}

