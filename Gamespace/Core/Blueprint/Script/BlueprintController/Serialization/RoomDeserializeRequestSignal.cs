namespace Gamespace.Core.Blueprint.Serialization
{
    public class RoomDeserializeRequestSignal
    {
        
    }

    public class RoomDeserializeResponseSignal
    {
        public RoomData[] data => _data;
        private RoomData[] _data;

        public RoomDeserializeResponseSignal(RoomData[] data)
        {
            _data = data;
        }
    }
}