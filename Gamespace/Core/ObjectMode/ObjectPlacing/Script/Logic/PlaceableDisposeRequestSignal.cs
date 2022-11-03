namespace Gamespace.Core.ObjectMode
{
    public class PlaceableDisposeRequestSignal
    {
        public IPlaceableObject placeable => _placeable;
        private IPlaceableObject _placeable;
        
        public PlaceableDisposeRequestSignal()
        {
            _placeable = null;
        }
        public PlaceableDisposeRequestSignal(IPlaceableObject placeable)
        {
            _placeable = placeable;
        }
    }

    public class PlaceableDisposeResponseSignal
    {
        
    }
}