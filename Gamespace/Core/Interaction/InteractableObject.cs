using Gamespace.Core.ObjectMode;

namespace Gamespace.Core.Interaction
{
    public class InteractableObject : SimpleObject, IInteractable
    {
        private bool _isInteractable;
        public virtual void Interact()
        {
            if (!_isInteractable)
                return;
        }
        public override void SetActive(bool enabled)
        {
            _isInteractable = enabled;
        }
    }

}