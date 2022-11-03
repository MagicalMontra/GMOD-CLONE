namespace Gamespace.Core.ObjectMode
{
    public class PlaceableInitializeSignal
    {
        public IPlaceableObject placeable => _placeable;
        private IPlaceableObject _placeable;
        public PlaceableInitializeSignal(IPlaceableObject placeable)
        {
            _placeable = placeable;
        }
    }
}