using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gamespace.Network.Login;
using UnityEngine;
using Zenject;

namespace Gamespace.Network
{
    public class LoginTestMono : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        private bool _isInjected;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _isInjected = true;
        }
        public void Invoke()
        {
            Fire().Forget();
        }
        private async UniTaskVoid Fire()
        {
            await UniTask.WaitUntil(() => _isInjected);
            _signalBus.AbstractFire(new LoginPanelOpenSignal());
            await UniTask.Yield();
        }
    }
}
