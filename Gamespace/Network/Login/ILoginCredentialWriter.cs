using Cysharp.Threading.Tasks;

namespace Gamespace.Network.Login
{
    public interface ILoginCredentialWriter
    {
        UniTask<bool> Write(string data);
    }
}