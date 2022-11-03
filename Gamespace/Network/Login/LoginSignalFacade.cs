using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginSignalFacade : MonoBehaviour
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public void OpenPanel()
        {
            _signalBus.AbstractFire(new LoginPanelOpenSignal());
        }
        public void ClosePanel()
        {
            _signalBus.AbstractFire(new LoginPanelCloseSignal());
        }
    }
}