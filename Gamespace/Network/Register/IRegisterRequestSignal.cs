namespace Gamespace.Network.Register
{
    public interface IRegisterRequestSignal
    {
        RegisterRequestData data { get; }
        void Clear();
    }
}