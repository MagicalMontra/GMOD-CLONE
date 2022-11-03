using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Serialization
{
    [Serializable]
    public class ActionData : ObjectData
    {
        public string[] linkedObjectIds;
        
        public ActionData(ActionData data)
        {
            uniqueId = data.uniqueId;
            instanceId = data.instanceId;
            parentObjectId = data.parentObjectId;
            elevation = data.elevation;
            position = data.position;
            rotation = data.rotation;
            linkedObjectIds = data.linkedObjectIds;
        }
        public override ObjectData Clone()
        {
            return new ActionData(this);
        }
    }
}