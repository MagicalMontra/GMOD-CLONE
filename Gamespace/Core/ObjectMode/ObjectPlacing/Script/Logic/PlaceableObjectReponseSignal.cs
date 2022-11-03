namespace Gamespace.Core.ObjectMode
{
    public class PlaceableObjectReponseSignal
    {
        public string requestId => _requestId;
        public IPlaceableObject[] placeables => _placeables;
        private string _requestId;
        private IPlaceableObject[] _placeables;
        public PlaceableObjectReponseSignal(string requestId, IPlaceableObject[] placeables)
        {
            _requestId = requestId;
            _placeables = placeables;
        }

    }
}