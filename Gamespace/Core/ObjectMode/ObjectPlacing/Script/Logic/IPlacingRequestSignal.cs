namespace Gamespace.Core.ObjectMode.Placing
{
    public interface IPlacingRequestSignal
    {
        IPlaceableObject placeable { get; }
    }
}