using System;
using System.Collections.Generic;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode.Serialization;

namespace Gamespace.Core.Serialization
{
    [Serializable]
    public class SerializationMap
    {
        public string id;
        public List<RoomData> roomData = new List<RoomData>();
        public List<ObjectData> objectData = new List<ObjectData>();
    }
}