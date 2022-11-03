namespace Gamespace.Network.Register
{
    public class RegisterRequestSignal : IRegisterRequestSignal
    {
        public RegisterRequestData data => _data;

        private RegisterRequestData _data;

        public RegisterRequestSignal(RegisterRequestData data)
        {
            _data = data;
        }
        public void Clear()
        {
            _data = null;
        }
    }
}