using Gamespace.Core.Player;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    public interface INewPlacingRequestSignal
    {
        PlaceableObjectData data { get; }
    }
}