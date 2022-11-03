using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.Serialization;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class RoomDeserializer
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ISerializationReader<RoomData> _reader;

        public async void OnDeserializeRequest(RoomDeserializeRequestSignal requestSignal)
        {
            var data = await _reader.ReadAll();
            _signalBus.Fire(new RoomDeserializeResponseSignal(data));
        }
    }
}