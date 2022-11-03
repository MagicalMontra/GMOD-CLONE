using Cysharp.Threading.Tasks;

namespace Gamespace.Network.Login
{
    public interface ILoginCredentialReader
    {
        UniTask<string> Read();
    }
}