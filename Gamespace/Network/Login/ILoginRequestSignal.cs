namespace Gamespace.Network.Login
{
    public interface ILoginRequestSignal
    {
        bool isAutoLogin { get; }
        bool isRemembered { get; }
        LoginRequestData data { get; }
        void Clear();
    }
}