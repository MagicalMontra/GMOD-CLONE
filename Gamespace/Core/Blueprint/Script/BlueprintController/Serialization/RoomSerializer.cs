using nanoid;
using Zenject;
using Cysharp.Threading.Tasks;
using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.Serialization;
using Gamespace.UI.ProgressScreen;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class RoomSerializer
    {
        private string _requestId;
        
        [Inject] private SignalBus _signalBus;
        [Inject] private ISerializationQueueWorker<RoomData> _writer;
        
        public void OnSerializeRequest(RoomSerializeRequestSignal signal)
        {
            _requestId = NanoId.Generate(4);
            _signalBus.Fire(new RoomRequestSignal(_requestId));
        }
        public void OnRoomResponse(RoomResponseSignal signal)
        {
            Write(signal).Forget();
        }
        private async UniTaskVoid Write(RoomResponseSignal signal)
        {
            if (_requestId != signal.requestId)
            {
                await UniTask.Yield();
                return;
            }

            var counter = 1;
            
            for (int i = 0; i < signal.rooms.Length; i++)
            {
                _signalBus.Fire(new ProgressScreenRequestSignal(counter, signal.rooms.Length, $"Queuing Rooms"));
                _writer.Queue(signal.rooms[i].Serialize());
                counter++;
                await UniTask.Delay(150);
            }
            
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenCompleteSignal($"Queued Rooms"));
            _signalBus.Fire(new RoomSerializeResponseSignal());
            
            await UniTask.Yield();
        }
    }
}

