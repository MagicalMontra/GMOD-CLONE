using Gamespace.Core.Player;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableSelectSignal : INewPlacingRequestSignal, IPlaceableSurfaceRequestSignal, IPlaceablePanelCloseSignal, IPlayerUnlockSignal, IObjectSelectionDisableSignal
    {
        public string lockId => _lockId;
        public string playerId => _playerId;
        public string id => "PlacingObject";
        public string requestId => "PlacingObject";
        
        public PlaceableObjectData data => _data;

        private string _requestId;
        private string _playerId;
        private string _lockId;
        private PlaceableObjectData _data;

        public PlaceableSelectSignal(string playerId, string lockId, PlaceableObjectData data)
        {
            _playerId = playerId;
            _lockId = lockId;
            _data = data;
        }
    }
}