using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public interface IRotationRequestSignal
    {
        IRotatable rotatable { get; }
    }

    public class PlaceableRotateRequestSignal : IRotationRequestSignal, IObjectSelectionDisableSignal
    {
        public string id => "RotatingObject";
        public IRotatable rotatable => _rotatable;
        private IRotatable _rotatable;

        public PlaceableRotateRequestSignal(IRotatable rotatable)
        {
            _rotatable = rotatable;
        }
    }

    public class PlaceableRotateExitRequestSignal
    {

    }
}