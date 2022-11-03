using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gamespace.Network.Login;

namespace Gamespace.Network
{
    public interface ILoginEncryptionWorker
    {
        UniTask<bool> Encrypt(LoginRequestData data);
        UniTask<LoginRequestData> Decrypt();
    }
}