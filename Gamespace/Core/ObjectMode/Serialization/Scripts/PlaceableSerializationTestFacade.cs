using System;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class PlaceableSerializationTestFacade : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private KeyCode _saveKey;
        [SerializeField] private KeyCode _loadKey;

        private bool _isLoadKeyPressed;
        private bool _isSaveKeyPressed;
        private void Update()
        {
            if (Input.GetKeyUp(_saveKey))
                _isSaveKeyPressed = true;
            
            if (Input.GetKeyUp(_loadKey))
                _isLoadKeyPressed = true;
            
            if (_isLoadKeyPressed && !_isSaveKeyPressed)
            {
                _signalBus.Fire(new PlaceableDeserializeRequestSignal());
                _isLoadKeyPressed = false;
            }
            
            if (_isSaveKeyPressed && !_isLoadKeyPressed)
            {
                _signalBus.Fire(new PlaceableSerializeRequestSignal());
                _isSaveKeyPressed = false;
            }
        }
    }
}