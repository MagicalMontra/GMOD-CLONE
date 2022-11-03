namespace Gamespace.Core.Interaction
{
    public interface IPullable : IFacingInteractable
    {
        float value { get; }
        void Pull(float pullAmount);
    }
}

