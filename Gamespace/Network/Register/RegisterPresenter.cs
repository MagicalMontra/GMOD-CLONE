using Zenject;

namespace Gamespace.Network.Register
{
    public class RegisterPresenter
    {
        [Inject] private RegisterSettings _settings;
        [Inject] private IRegisterUI.Factory _registerUIFactory;
        
        private IRegisterUI _registerUI;
        
        public void OnRegisterPanelOpened(IRegisterPanelOpenSignal signal)
        {
            _registerUI ??= _registerUIFactory.Create(_settings.registerUIPrefab);
            _registerUI.OnCreate(_settings.mainCamera, signal.closeAction);
            _registerUI.SetActive(true);
        }

        public void OnRegisterPanelClosed(RegisterPanelCloseSignal signal)
        {
            _registerUI.SetActive(false);
        }
    }
}