using System.Collections.Generic;

namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public class PlaceableSurfaceResponseSignal
    {
        public string id => _id;
        public List<IPlaceableSurface> surfaces => _surfaces;

        private string _id;
        private List<IPlaceableSurface> _surfaces;

        public PlaceableSurfaceResponseSignal(string id, List<IPlaceableSurface> surfaces)
        {
            _id = id;
            _surfaces = surfaces;
        }
    }
}