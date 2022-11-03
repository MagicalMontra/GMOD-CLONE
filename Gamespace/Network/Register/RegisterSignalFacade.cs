using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gamespace.Network.Register
{
    public class RegisterSignalFacade : MonoBehaviour
    {
        public UnityEvent closeAction;
        
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public void Open()
        {
            _signalBus.AbstractFire(new RegisterPanelOpenSignal(closeAction.Invoke));
        }
        public void Close()
        {
            _signalBus.AbstractFire(new RegisterPanelCloseSignal());
        }
    }
}