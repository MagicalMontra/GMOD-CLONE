using Gamespace.Core.ObjectMode.PlaceableSurface;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    public interface ISurfaceSelectionWorker
    {
        int Select(IPlaceableSurface[] surfaces, Ray ray);
    }
}