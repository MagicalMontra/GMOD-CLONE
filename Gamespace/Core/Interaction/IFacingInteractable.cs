namespace Gamespace.Core.Interaction
{
    public interface IFacingInteractable : IInteractable
    {
        float lookThreshold { get; }
        float lookPercentage { get; set; }
    }

}

