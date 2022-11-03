using Cysharp.Threading.Tasks;

namespace Gamespace.Core.Serialization
{
    public interface ISerializationWriter
    {
        UniTask<bool> Write();
    }

    public interface ISerializationQueueWorker<TContract>
    {
        void Queue(TContract contract);
    }
}