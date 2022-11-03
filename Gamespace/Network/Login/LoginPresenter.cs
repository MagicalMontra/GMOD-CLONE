using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginPresenter : IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private LoginSettings _settings;
        [Inject] private ILoginUI.Factory _loginUIFactory;
        [Inject] private LoginPlayerPrefsMapper _playerPrefsMapper;
        [Inject] private AutoLoginPromptUI.Factory _autoLoginUIFactory;
        [Inject] private ILoginEncryptionWorker _loginEncryptionWorker;

        private ILoginUI _loginUI;
        private AutoLoginPromptUI _autoLoginPromptUI;
        
        public void Initialize()
        {
            _loginUI = _loginUIFactory.Create(_settings.loginUIPrefab);
        }
        public void OnLoginPanelOpenRequest(ILoginPanelOpenSignal signal)
        {
            LoginPanelOpen().Forget();
        }
        public void OnLoginPanelCloseRequest(LoginPanelCloseSignal signal)
        {
            _loginUI.SetActive(false);
        }
        private async UniTaskVoid LoginPanelOpen()
        {
            var data = new LoginRequestData();
            
            if (File.Exists($"{Application.persistentDataPath}/{_settings.rememberPath}")) 
                data = await _loginEncryptionWorker.Decrypt();

            if (IsAutoLogin())
            {
                _autoLoginPromptUI ??= _autoLoginUIFactory.Create(_settings.autoLoginUIPrefab);
                _autoLoginPromptUI.Push(() => _signalBus.AbstractFire(new LoginRequestSignal(true, true, data)), () => OpenLoginPanel(data.email));
                await UniTask.Yield();
                return;
            }

            OpenLoginPanel(data.email);
            
            data = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            await UniTask.Yield();
        }
        private void OpenLoginPanel(string email)
        {
            _loginUI ??= _loginUIFactory.Create(_settings.loginUIPrefab);
            _loginUI.SetActive(true);
            _loginUI.OnCreate(IsRemembered(), email, _settings.uiCamera);
        }
        private bool IsRemembered()
        {
            var isRemembered = _playerPrefsMapper.GetKey(_settings.rememberKey).AsBool;

            if (!File.Exists($"{Application.persistentDataPath}/{_settings.rememberPath}"))
                return false;
            
            return isRemembered;
        }
        private bool IsAutoLogin()
        {
            var isAutoLoggedIn = _playerPrefsMapper.GetKey(_settings.autoLoginKey).AsBool;
            
            if (!File.Exists($"{Application.persistentDataPath}/{_settings.rememberPath}"))
                return false;
            
            return isAutoLoggedIn;
        }
    }
}