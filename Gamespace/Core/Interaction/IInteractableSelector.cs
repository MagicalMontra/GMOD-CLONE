namespace Gamespace.Core.Interaction
{
    public interface IInteractableSelector
    {
        IInteractable selectedInteractable { get; }
        void GetInteractable();
        void DisableAll();
    }

}
