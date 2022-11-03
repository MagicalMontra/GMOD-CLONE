using System;
using Cysharp.Threading.Tasks;
using Gamespace.Localization;
using Gamespace.UI;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginController
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private LoginSettings _settings;
        [Inject] private LoginRequestWorker _requestWorker;
        [Inject] private TranslatorFacade _translatorFacade;
        [Inject] private LoginPlayerPrefsMapper _playerPrefsMapper;
        [Inject] private ILoginEncryptionWorker _loginEncryptionWorker;
        
        public void OnLoginRequestSignal(ILoginRequestSignal signal)
        {
            LoginRequestSignal(signal).Forget();
        }
        private async UniTaskVoid LoginRequestSignal(ILoginRequestSignal signal)
        {
            _signalBus.Fire(new LoadingScreenRequestSignal());
            
            await UniTask.Delay(1000);
            
            _signalBus.Fire(new LoginPanelCloseSignal());
            
            var response = await _requestWorker.Request(signal.data);

            await UniTask.Delay(1500);

            if (response.error.statusCode == 0)
            {
                bool isWritten;
                if (signal.isRemembered)
                {
                    await _playerPrefsMapper.SetInstanceKey();
                    isWritten = await _loginEncryptionWorker.Encrypt(signal.data);
                }
                else
                {
                    signal.data.email = "";
                    signal.data.password = "";
                    isWritten = await _loginEncryptionWorker.Encrypt(signal.data);
                }
                
                _playerPrefsMapper.ModifyKey(_settings.autoLoginKey, signal.isAutoLogin && isWritten);
                _playerPrefsMapper.ModifyKey(_settings.rememberKey, isWritten);
            }
            else
            {
                _playerPrefsMapper.ModifyKey(_settings.autoLoginKey, false);
                _signalBus.Fire(new NotificationRequestSignal(response.error.error, response.error.message, "Dismiss", () => _signalBus.AbstractFire(new LoginPanelOpenSignal())));
            }
            
            _signalBus.Fire(new LoadingScreenCancelSignal());

            signal.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            await UniTask.Yield();
        }
    }
}