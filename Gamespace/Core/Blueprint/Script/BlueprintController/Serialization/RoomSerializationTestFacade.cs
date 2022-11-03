using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.ObjectMode;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class RoomSerializationTestFacade : MonoBehaviour
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
                _signalBus.Fire(new RoomDeserializeRequestSignal());
                _isLoadKeyPressed = false;
            }
            
            if (_isSaveKeyPressed && !_isLoadKeyPressed)
            {
                _signalBus.Fire(new RoomSerializeRequestSignal());
                _isSaveKeyPressed = false;
            }
        }
    }
}