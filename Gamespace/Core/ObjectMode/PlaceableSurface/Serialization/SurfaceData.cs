using System;

namespace Gamespace.Core.ObjectMode.PlaceableSurface.Serialization
{
    [Serializable]
    public class SurfaceData
    {
        public string id;

        public SurfaceData()
        {
            id = "";
        }
        public SurfaceData(SurfaceData data)
        {
            id = data.id;
        }
        public SurfaceData Clone()
        {
            return new SurfaceData(this);
        }
    }
}