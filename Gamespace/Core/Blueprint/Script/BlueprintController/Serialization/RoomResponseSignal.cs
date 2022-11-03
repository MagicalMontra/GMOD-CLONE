using Gamespace.Core.Blueprint.Room;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomRequestSignal
    {
        public string requestId => _requestId;
        public string specifier => _specifier;
        private string _requestId;
        private string _specifier;
        
        public RoomRequestSignal(string requestId, string specifier = "")
        {
            _requestId = requestId;
            _specifier = specifier;
        }
    }
    public class RoomResponseSignal
    {
        public string requestId => _requestId;
        public RoomBase[] rooms => _rooms;

        private string _requestId;
        private RoomBase[] _rooms;

        public RoomResponseSignal(string requestId, RoomBase[] rooms)
        {
            _requestId = requestId;
            _rooms = rooms;
        }
    }
}