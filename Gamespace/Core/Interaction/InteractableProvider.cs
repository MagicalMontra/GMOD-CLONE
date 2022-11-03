using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.Player;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class InteractableInitializeSignal
    {
        public IInteractable interactable => _interactable;
        private IInteractable _interactable;

        public InteractableInitializeSignal(IInteractable interactable)
        {
            _interactable = interactable;
        }
    }
    public class InteractableDisposeSignal
    {
        public string id => _id;
        private string _id;

        public InteractableDisposeSignal(string id)
        {
            _id = id;
        }
    }
    public class InteractableProvider : ITickable
    {
        [Inject] private InteractableDistanceBiasWorker _interactableDistanceBiasWorker;
        private List<IInteractable> _interactables = new List<IInteractable>();

        public void OnInteractableInitialized(InteractableInitializeSignal signal)
        {
            if (_interactables.Exists(o => o.id == signal.interactable.id))
                return;

            _interactables.Add(signal.interactable);
        }
        public void OnInteractableDisposed(InteractableDisposeSignal signal)
        {
            for (int i = 0; i < _interactables.Count; i++)
            {
                if (_interactables[i].id != signal.id)
                    continue;

                _interactables[i].OnDispose();
                // Object.Destroy(_interactables[i].gameObject);
                _interactables.RemoveAt(i);
            }
        }
        public IInteractable[] GetInDistanceObjects(float distance)
        {
            return _interactables.FindAll(o => o.distanceFromPlayer <= distance).ToArray();
        }
        public void Tick()
        {
            if (_interactables.Count < 0)
                return;

            _interactableDistanceBiasWorker.SetDistance(_interactables);
        }
    }

}
