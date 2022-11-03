using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectProvider : ITickable
    {
        public int count => _placeableObjects.Count;
        public List<IPlaceableObject> placeableObjects => _placeableObjects;

        [Inject] private SignalBus _signalBus;
        [Inject] private ObjectDistanceBiasWorker _objectDistanceBiasWorker;
        
        private List<IPlaceableObject> _placeableObjects = new List<IPlaceableObject>();
        private List<IPlaceableObject> _discardedObjects = new List<IPlaceableObject>();
        public async void Add(IPlaceableObject newObject)
        {
            newObject.OnInitialize();
            var placeable = HandleDuplicateId(newObject);
            _placeableObjects.Add(placeable);
        }
        public void Remove(IPlaceableObject objectToRemove)
        {
            for (int i = 0; i < _placeableObjects.Count; i++)
            {
                if (_placeableObjects[i].id != objectToRemove.id)
                    continue;

                _discardedObjects.Add(_placeableObjects[i]);
                _placeableObjects.RemoveAt(i);
            }

            for (int i = 0; i < _discardedObjects.Count; i++)
            {
                _discardedObjects[i].OnDispose();
            }
            
            _discardedObjects.Clear();
            _signalBus.Fire(new PlaceableDisposeResponseSignal());
        }
        public void Remove()
        {
            for (int i = 0; i < _placeableObjects.Count; i++)
            {
                _discardedObjects.Add(_placeableObjects[i]);
            }
            
            _placeableObjects.Clear();

            for (int i = 0; i < _discardedObjects.Count; i++)
            {
                _discardedObjects[i].OnDispose();
            }
            
            _discardedObjects.Clear();
            _signalBus.Fire(new PlaceableDisposeResponseSignal());
        }
        private IPlaceableObject HandleDuplicateId(IPlaceableObject duplicatedObject)
        {
            var placeable = duplicatedObject;
            if (_placeableObjects.Exists(o => o.id == duplicatedObject.id))
                placeable.OnInitialize();

            return placeable;
        }
        public void OnPlaceableInitialized(PlaceableInitializeSignal signal)
        {
            Add(signal.placeable);
        }
        public void OnPlaceableDispose(PlaceableDisposeRequestSignal signal)
        {
            if (signal.placeable is null)
            {
                Remove();
                return;
            }

            Remove(signal.placeable);
        }
        public void OnPlaceableRequested(PlaceableObjectRequestSignal signal)
        {
            List<IPlaceableObject> matches;
            IPlaceableObject[] total;

            if (string.IsNullOrEmpty(signal.specifier))
            {
                total = _placeableObjects.ToArray();
                _signalBus.Fire(new PlaceableObjectReponseSignal(signal.requestId, total));
                return;
            }
            
            matches = _placeableObjects.FindAll(placeable => signal.specifier.ToLower().Contains(placeable.id.ToLower()));
            total = matches.Concat(_placeableObjects.FindAll(placeable => placeable.id == signal.specifier)).ToArray();
            _signalBus.Fire(new PlaceableObjectReponseSignal(signal.requestId, total));
        }

        public void Tick()
        {
            if (_discardedObjects.Count > 0)
                return;

            for (int i = 0; i < _placeableObjects.Count; i++)
            {
                if (_placeableObjects[i] is null)
                    continue;
                
                _objectDistanceBiasWorker.SetDistance(_placeableObjects[i]);
            }
        }
    }
}