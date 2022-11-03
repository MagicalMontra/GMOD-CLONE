using Gamespace.Core.ObjectMode;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public class SerializationController : IInitializable, ILateDisposable
    {
        [Inject] private SerializationSettings _settings;
        [Inject] private SerializeSequenceWorker _serializeSequenceWorker;
        [Inject] private DeserializeSequenceWorker _deserializeSequenceWorker;
        
        public void Initialize()
        {
            _settings.map = new SerializationMap();
        }
        public void LateDispose()
        {
            _settings.map = new SerializationMap();
        }
        public void OnDeserializeRequest(DeserializeRequestSignal signal)
        {
            _settings.fileName = signal.sceneName;
            _deserializeSequenceWorker.StartSequence();
        }
        public void OnSerializeRequest(SerializeRequestSignal signal)
        {
            _settings.fileName = signal.sceneName;
            _serializeSequenceWorker.StartSequence().Forget();
        }
    }
}