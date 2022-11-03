using Cysharp.Threading.Tasks;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode.Serialization;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public class SerializeSequenceWorker
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ISerializationWriter _writer;
        [Inject] private SerializationSettings _settings;

        private int _count;
        private bool _isWriting;
        
        public async UniTaskVoid StartSequence()
        {
            await UniTask.WaitUntil(() => !_isWriting);
            await UniTask.WaitUntil(() => _count <= 0);
            _settings.map = new SerializationMap();
            _signalBus.Fire(new RoomSerializeRequestSignal());
            _isWriting = true;
        }
        public void OnRoomSerializeResponse(RoomSerializeResponseSignal signal)
        {
            _count++;
            _signalBus.Fire(new PlaceableSerializeRequestSignal());
        }
        public async void OnPlaceableSerializeResponse(PlaceableSerializeResponseSignal signal)
        {
            var isSucceed = await _writer.Write();
            _count--;
            Debug.Log(isSucceed);
            _isWriting = false;
        }
    }
}