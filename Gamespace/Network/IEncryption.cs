using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Gamespace.Utilis.Encryption
{
    public interface IEncryption
    {
        UniTask<string> Encrypt(string data);
        UniTask<string> Decrypt(string data);
    }
}