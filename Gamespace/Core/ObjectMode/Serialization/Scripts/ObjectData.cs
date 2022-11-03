using System;

namespace Gamespace.Core.ObjectMode.Serialization
{
    [Serializable]
    public class ObjectData
    {
        public string uniqueId;
        public string instanceId;
        public string parentObjectId;
        public float elevation;
        public DVector3 position;
        public DQuaternion rotation;

        public ObjectData()
        {

        }
        public ObjectData(ObjectData data)
        {
            uniqueId = data.uniqueId;
            instanceId = data.instanceId;
            parentObjectId = data.parentObjectId;
            elevation = data.elevation;
            position = data.position;
            rotation = data.rotation;
        }
        public virtual ObjectData Clone()
        {
            return new ObjectData(this);
        }
    }
}