using Zenject;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class PlaceableObjectDeserializer
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ISerializationReader<ObjectData> _reader;

        public async void OnDeserializeRequest(PlaceableDeserializeRequestSignal signal)
        {
            var objectData = await _reader.ReadAll();
            _signalBus.Fire(new PlaceableDeserializeResponseSignal(objectData));
        }
    }
}