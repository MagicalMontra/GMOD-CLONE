using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gamespace.Core.Blueprint.Room;
using Zenject;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.UI.ProgressScreen;
using UnityEngine;

namespace Gamespace.Core.Serialization
{
    public class DeserializeSequenceWorker
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private SerializationSettings _settings;
        [Inject] private SerializeRoomFactory _roomFactory;
        [Inject] private SerializePlaceableFactory _placeableFactory;

        private RoomData[] _loadedRooms;
        private ObjectData[] _loadedObjects;
        public void StartSequence()
        {
            _signalBus.Fire(new PlaceableDisposeRequestSignal());
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Disposing Objects"));
        }
        public async void OnPlaceableDisposeResponse(PlaceableDisposeResponseSignal signal)
        {
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenRequestSignal(1, 1, "Disposed Objects"));
            await UniTask.Delay(400);
            _signalBus.Fire(new RoomDeserializeRequestSignal());
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Loading Rooms"));
        }
        public async void OnRoomDeserializeResponse(RoomDeserializeResponseSignal signal)
        {
            await UniTask.Delay(400);
            _loadedRooms = signal.data;
            _signalBus.Fire(new ProgressScreenCompleteSignal("Loaded Rooms"));
            await UniTask.Delay(400);
            _signalBus.Fire(new PlaceableSurfaceDisposeRequestSignal());
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Disposing Surfaces"));
        }
        public async void OnPlaceableSurfaceDisposeResponse(PlaceableSurfaceDisposeResponseSignal signal)
        {
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenRequestSignal(1, 1, "Disposed Surfaces"));
            await UniTask.Delay(400);
            _signalBus.Fire(new RoomDisposeRequestSignal());
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Disposing Rooms"));
        }
        public async void OnRoomDisposeResponse(RoomDisposeResponseSignal signal)
        {
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenRequestSignal(1, 1, "Disposed Rooms"));

            var counter = 0;
            
            for (int i = 0; i < _loadedRooms.Length; i++)
            {
                var instance = _roomFactory.Create(_loadedRooms[i].uniqueId);
                instance.Deserialize(_loadedRooms[i]);
                counter++;
                _signalBus.Fire(new RoomInitializeSignal(instance));
                _signalBus.Fire(new ProgressScreenRequestSignal(counter, _loadedRooms.Length, "Initializing Rooms"));
                await UniTask.Delay(Mathf.CeilToInt(1500 / _loadedRooms.Length));
            }
            
            _signalBus.Fire(new ProgressScreenCompleteSignal("Initialized Rooms"));
            await UniTask.Delay(300);
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Loading Objects"));
            _signalBus.Fire(new PlaceableDeserializeRequestSignal());
        }
        public async void OnPlaceableDeserializeResponse(PlaceableDeserializeResponseSignal signal)
        {
            await UniTask.Delay(400);
            _loadedObjects = signal.data;
            _signalBus.Fire(new ProgressScreenCompleteSignal("Loaded Objects"));
            await UniTask.Delay(400);
            _signalBus.AbstractFire(new PlaceableSurfaceRequestSignal("Load"));
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, "Validating Surfaces Availability")); 
        }
        public async void OnPlaceableSurfaceResponse(PlaceableSurfaceResponseSignal signal)
        {
            await UniTask.Delay(400);
            _signalBus.Fire(new ProgressScreenCompleteSignal("Validated Surfaces Availability"));
            
            if (signal.id != "Load")
                return;

            await UniTask.Delay(200);
            var counter = 0;
            
            for (int i = 0; i < _loadedObjects.Length; i++)
            {
                var placeable = _placeableFactory.Create(_loadedObjects[i].uniqueId);
                placeable.OnCreateCandidate();
                placeable.Deserialize(_loadedObjects[i]);
                
                var surfaceIndex = signal.surfaces.FindIndex(surface => surface.id == _loadedObjects[i].parentObjectId);
                
                if (surfaceIndex > -1)
                    placeable.SetParent(signal.surfaces[surfaceIndex]);

                counter++;
                
                _signalBus.Fire(new PlaceableInitializeSignal(placeable));
                _signalBus.Fire(new ProgressScreenRequestSignal(counter, _loadedObjects.Length, "Initializing Objects")); 
                await UniTask.Delay(Mathf.CeilToInt(1500 / _loadedObjects.Length));
            }
            
            _signalBus.Fire(new ProgressScreenCompleteSignal("Initialized Objects Complete"));
        }
    }
}