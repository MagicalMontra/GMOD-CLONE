using UnityEngine;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public class SerializeSequenceTestFacade : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private KeyCode _key;

        private bool _isPressed;
        private void Update()
        {
            if (Input.GetKeyUp(_key))
                _isPressed = true;
            
            if (_isPressed)
            {
                _signalBus.Fire(new SerializeRequestSignal("Test"));
                _isPressed = false;
            }
        }
    }
}