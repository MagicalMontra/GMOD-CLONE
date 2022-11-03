using Gamespace.Core.ObjectMode.Selection;
using Gamespace.Core.Player;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class ObjectElevationRequestSignal : IObjectElevationRequestSignal, IObjectSelectionDisableSignal
    {
        public IElevatable elevatable => _elevatable;
        private IElevatable _elevatable;

        public ObjectElevationRequestSignal(IElevatable elevatable)
        {
            _elevatable = elevatable;
        }

        public string id => "ElevatingObject";
    }
}