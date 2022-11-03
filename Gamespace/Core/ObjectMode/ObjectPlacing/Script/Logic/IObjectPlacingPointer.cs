using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    public interface IObjectPlacingPointer
    {
        void SetPointer(PlacingData data);
        void SetDisable();
    }
}