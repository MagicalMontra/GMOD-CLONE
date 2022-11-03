using System;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.Core.ObjectMode.PlaceableSurface.Serialization;

namespace Gamespace.Core.Blueprint.Serialization
{
    [Serializable]
    public class RoomData
    {
        public string uniqueId;
        public string instanceId;
        public DVector3 position;
        public DQuaternion rotation;
        public SurfaceData[] surfaces;
        
        public RoomData()
        {

        }
        public RoomData(RoomData data)
        {
            uniqueId = data.uniqueId;
            instanceId = data.instanceId;
            position = data.position;
            rotation = data.rotation;

            surfaces = new SurfaceData[data.surfaces.Length];
            for (int i = 0; i < data.surfaces.Length; i++)
                surfaces[i] = data.surfaces[i].Clone();
        }
        public virtual RoomData Clone()
        {
            return new RoomData(this);
        }
    }
}