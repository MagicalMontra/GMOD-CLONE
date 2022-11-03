using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gamespace.Network
{
    public class CredentialValidate : MonoBehaviour
    {
        public UnityEvent onAccessExpired;
        public UnityEvent onRefreshExpired;
        
        [Inject] private SignalBus _signalBus;
        
        public void Validate()
        {
            _signalBus.Fire(new CredentialRequestSignal().OnAccessExpired(onAccessExpired.Invoke).OnRefreshExpired(onRefreshExpired.Invoke));
        }
    }
}