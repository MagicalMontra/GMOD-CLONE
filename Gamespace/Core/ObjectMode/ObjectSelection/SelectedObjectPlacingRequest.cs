using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class SelectedObjectPlacingRequest : IPlacingRequestSignal, IPlaceableSurfaceRequestSignal, IObjectSelectionDisableSignal
    {
        public string id => "PlacingObject";
        public string requestId => "PlacingObject";
        public IPlaceableObject placeable => _placeable;

        private string _requestId;
        
        private IPlaceableObject _placeable;
        public SelectedObjectPlacingRequest(IPlaceableObject placeable)
        {
            _placeable = placeable;
        }
    }
}