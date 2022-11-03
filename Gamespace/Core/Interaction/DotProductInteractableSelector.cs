using UnityEngine;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class DotProductInteractableSelector : IInteractableSelector
    {
        public IInteractable selectedInteractable
        {
            get
            {
                if (_index > -1)
                    return _interactables[_index];

                return null;
            }
        }

        private int _index = -1;
        private IInteractable[] _interactables;
        [Inject] private InteractableSettings _settings;
        [Inject] private InteractableProvider _interactableProvider;

        public void GetInteractable()
        {
            _interactables = _interactableProvider.GetInDistanceObjects(6f);
            Ray _rayOrigin = _settings.camera.ViewportPointToRay(Vector3.one * 0.5f);

            var closet = 0f;
            _index = -1;

            for (int i = 0; i < _interactables.Length; i++)
            {
                if (_interactables[i] is null)
                    continue;
            
                if (_interactables[i] as IFacingInteractable is null)
                    continue;

                var interactable = _interactables[i] as IFacingInteractable;

                Vector3 v1 = _rayOrigin.direction;
                Vector3 v2 = interactable.position - _rayOrigin.origin;
                interactable.lookPercentage = Vector3.Dot(v1.normalized, v2.normalized);
                interactable.distanceFromPlayer = Vector3.Distance(interactable.position, _settings.camera.transform.position);

                var isCloset = interactable.lookPercentage > closet;
                var isPassedThreshold = interactable.lookPercentage > interactable.lookThreshold;

                if (isCloset && isPassedThreshold)
                {
                    closet = interactable.lookPercentage;
                    _index = i;
                }
            }
        }
        public void DisableAll()
        {
            if (_interactables is null)
                return;
            
            for (int i = 0; i < _interactables.Length; i++)
                _interactables[i].SetActive(false);
        }
    }

}
