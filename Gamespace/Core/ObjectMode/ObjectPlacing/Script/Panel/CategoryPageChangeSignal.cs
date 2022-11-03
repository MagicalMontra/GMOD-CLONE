using Gamespace.Core.ObjectMode.Selection;
using Gamespace.Core.Player;
using Gamespace.UI;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class CategoryPageChangeSignal : ICategoryPanelChangeSignal
    {
        public PlaceableObjectCategory category => _category;
        private PlaceableObjectCategory _category;

        public CategoryPageChangeSignal(PlaceableObjectCategory category)
        {
            _category = category;
        }
    }

    public class PlaceableObjectPanelOpenSignal : IPlaceablePanelOpenSignal, IPlayerLockSignal, ICircleWheelCloseRequest, IObjectSelectionDisableSignal
    {
        public string lockId => _lockId;
        public string playerId => _playerId;
        public string id => "PlaceableObjectPanel";
        private string _playerId;
        private string _lockId;

        public PlaceableObjectPanelOpenSignal(string playerId, string lockId)
        {
            _playerId = playerId;
            _lockId = lockId;
        }
    }

    public class PlaceableObjectPanelCancelSignal : IPlaceablePanelCloseSignal, IPlayerUnlockSignal, IObjectSelectionEnableSignal
    {
        public string lockId => _lockId;
        public string playerId => _playerId;
        public string id => "PlaceableObjectPanel";
        private string _playerId;
        private string _lockId;

        public PlaceableObjectPanelCancelSignal(string playerId, string lockId)
        {
            _playerId = playerId;
            _lockId = lockId;
        }
    }
}