using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public class RaycastInteractableSelector : IInteractableSelector
    {
        public IInteractable selectedInteractable => _selectedInteractable;

        private Ray  _rayOrigin;
        private RaycastHit _hit;
        private IInteractable _selectedInteractable;

        public void GetInteractable()
        {
            _rayOrigin = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

            if (Physics.Raycast(_rayOrigin, out _hit, 10f))
            {
                Debug.DrawRay(_rayOrigin.direction, _hit.point, Color.yellow);

                var hitInteractable = _hit.transform.GetComponent<IInteractable>();

                if (hitInteractable is null)
                {
                    _selectedInteractable = null;
                    return;
                }

                if (_selectedInteractable is null)
                {
                    _selectedInteractable = hitInteractable;
                    return;
                }

                if (_selectedInteractable.id != hitInteractable.id)
                    _selectedInteractable = hitInteractable;
            }
        }
        public void DisableAll()
        {
            
        }
    }

}
