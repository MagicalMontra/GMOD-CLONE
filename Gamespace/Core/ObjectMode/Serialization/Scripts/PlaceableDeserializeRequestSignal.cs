using System.Collections.Generic;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class PlaceableDeserializeRequestSignal
    {

    }
    public class PlaceableDeserializeResponseSignal
    {
        public ObjectData[] data => _data;
        private ObjectData[] _data;
        public PlaceableDeserializeResponseSignal(ObjectData[] data)
        {
            _data = data;
        }
    }
}