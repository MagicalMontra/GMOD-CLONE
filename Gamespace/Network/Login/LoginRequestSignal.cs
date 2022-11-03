namespace Gamespace.Network.Login
{
    public class LoginRequestSignal : ILoginRequestSignal
    {
        public bool isAutoLogin => _isAutoLogin;
        public bool isRemembered => _isRemembered;
        public LoginRequestData data => _data;

        private bool _isAutoLogin;
        private bool _isRemembered;
        private LoginRequestData _data;

        public LoginRequestSignal(bool isAutoLogin, bool isRemembered, LoginRequestData data)
        {
            _isAutoLogin = isAutoLogin;
            _isRemembered = isRemembered;
            _data = data;
        }
        public void Clear()
        {
            _data = null;
        }
    }
}