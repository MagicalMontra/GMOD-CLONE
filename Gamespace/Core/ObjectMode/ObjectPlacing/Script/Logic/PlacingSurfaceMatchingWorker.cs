using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlacingSurfaceMatchingWorker
    {
        public bool MatchSurface(IPlaceableObject placeable, IPlaceableSurface surface)
        {
            if (placeable.placeType == PlaceType.Floatable)
                return true;

            if (placeable.placeType == PlaceType.Stackable)
                return true;

            return placeable.placeType == surface.placeType;
        }
    }
}