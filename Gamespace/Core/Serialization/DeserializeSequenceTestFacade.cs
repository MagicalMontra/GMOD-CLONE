using UnityEngine;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public class DeserializeSequenceTestFacade : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private KeyCode _key;

        private bool _isPressed;
        private void Update()
        {
            if (Input.GetKeyDown(_key))
                _isPressed = true;

            if (Input.GetKeyUp(_key))
            {
                if (_isPressed)
                {
                    _signalBus.Fire(new DeserializeRequestSignal("Test"));
                }
                
                _isPressed = false;
            }
        }
    }
}