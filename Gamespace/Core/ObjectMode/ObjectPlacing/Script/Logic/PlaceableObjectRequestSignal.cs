namespace Gamespace.Core.ObjectMode
{
    public class PlaceableObjectRequestSignal
    {
        public string requestId => _requestId;
        public string specifier => _specifier;
        private string _requestId;
        private string _specifier;
        public PlaceableObjectRequestSignal(string requestId, string specifier = "")
        {
            _requestId = requestId;
            _specifier = specifier;
        }
    }
}