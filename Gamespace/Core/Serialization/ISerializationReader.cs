using Cysharp.Threading.Tasks;

namespace Gamespace.Core.Serialization
{
    public interface ISerializationReader<TContract>
    {
        UniTask<TContract> Read(string key);
        UniTask<TContract[]> ReadAll();
    }
}