using nanoid;
using Zenject;
using Cysharp.Threading.Tasks;
using Gamespace.Core.Serialization;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.UI.ProgressScreen;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class PlaceableObjectSerializer
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ISerializationQueueWorker<ObjectData> _writer;

        private string _requestId;
        private IPlaceableObject[] _placeableObjects;
        
        public void OnSerializeRequest(PlaceableSerializeRequestSignal requestSignal)
        {
            _requestId = NanoId.Generate(4);
            _signalBus.Fire(new PlaceableObjectRequestSignal(_requestId));
        }
        public void OnPlaceableProviderResponse(PlaceableObjectReponseSignal signal)
        {
            Write(signal).Forget();
        }
        private async UniTaskVoid Write(PlaceableObjectReponseSignal signal)
        {
            if (_requestId != signal.requestId)
            {
                await UniTask.Yield();
                return;
            }

            var counter = 1;

            for (int i = 0; i < signal.placeables.Length; i++)
            {
                _signalBus.Fire(new ProgressScreenRequestSignal(counter, signal.placeables.Length, "Queuing Objects"));
                _writer.Queue(signal.placeables[i].Serialize());
                counter++;
                await UniTask.Delay(Mathf.CeilToInt(3000 / signal.placeables.Length));
            }
            
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenCompleteSignal($"Queued Objects"));
            _signalBus.Fire(new PlaceableSerializeResponseSignal());

            await UniTask.Yield();
        }
    }
}