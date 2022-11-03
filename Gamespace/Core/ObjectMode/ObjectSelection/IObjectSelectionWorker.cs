using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Selection
{
    public interface IObjectSelectionWorker
    {
        int Select(List<IPlaceableObject> placeableObjects, Ray ray);
    }
}