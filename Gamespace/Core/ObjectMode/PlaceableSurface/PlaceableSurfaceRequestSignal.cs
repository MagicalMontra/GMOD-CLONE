namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public class PlaceableSurfaceRequestSignal : IPlaceableSurfaceRequestSignal
    {
        public string requestId => _id;
        private string _id;
        public PlaceableSurfaceRequestSignal(string id)
        {
            _id = id;
        }
    }
}