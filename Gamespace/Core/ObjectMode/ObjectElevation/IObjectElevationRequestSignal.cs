using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public interface IObjectElevationRequestSignal
    {
        IElevatable elevatable { get; }
    }
    public class ObjectElevationExitRequestSignal : IObjectSelectionEnableSignal
    {
        public string id => "ElevatingObject";
    }
    public class ObjectElevationExitResponseSignal : IObjectSelectionEnableSignal
    {
        public string id => "ElevatingObject";
    }
}