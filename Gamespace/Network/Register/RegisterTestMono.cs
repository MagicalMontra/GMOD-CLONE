using nanoid;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Register
{
    public class RegisterTestMono : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        
        public void Invoke()
        {
            var data = new RegisterRequestData();
            data.firstname = NanoId.Generate(6);
            data.lastname = NanoId.Generate(6);
            data.email = $"{NanoId.Generate(6)}@{NanoId.Generate(4)}.com";
            data.mobile = NanoId.Generate("0123456789", 8);
            data.password = "123456789";
            _signalBus.AbstractFire(new RegisterRequestSignal(data));
        }
    }
}