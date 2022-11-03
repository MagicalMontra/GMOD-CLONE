using System;
using Zenject;
using Gamespace.UI;
using Cysharp.Threading.Tasks;
using Gamespace.Localization;

namespace Gamespace.Network.Register
{
    public class RegisterController
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private RegisterSettings _settings;
        [Inject] private TranslatorFacade _translator;
        [Inject] private RegisterRequestWorker _requestWorker;

        public void OnRegisterRequest(IRegisterRequestSignal signal)
        {
            RegisterRequest(signal).Forget();
        }
        private async UniTaskVoid RegisterRequest(IRegisterRequestSignal signal)
        {
            _signalBus.Fire(new LoadingScreenRequestSignal());
            
            await UniTask.Delay(1000);
            
            _signalBus.Fire(new RegisterPanelCloseSignal());
            
            var response = await _requestWorker.Request(signal.data);
            
            await UniTask.Delay(1500);

            if (response.error.statusCode == 0)
            {
                _translator.Translate("Register", "registerCompletedTitle", (registerCompletedTitle) =>
                {
                    _translator.Translate("Register", "registerCompletedContext", (registerCompletedContext) =>
                    {
                        _signalBus.Fire(new NotificationRequestSignal(registerCompletedTitle, registerCompletedContext, "Yay", () => _settings.loginCaller.Invoke()));
                    });
                });
            }
            else
            {
                _signalBus.Fire(new NotificationRequestSignal(response.error.error, response.error.message, "Dismiss", () => _signalBus.AbstractFire(new RegisterPanelOpenSignal())));
            }
            
            _signalBus.Fire(new LoadingScreenCancelSignal());

            signal.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            await UniTask.Yield();
        }
    }
}