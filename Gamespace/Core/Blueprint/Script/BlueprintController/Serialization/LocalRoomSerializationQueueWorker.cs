using Cysharp.Threading.Tasks;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class LocalRoomSerializationQueueWorker : SerializationQueueWorker<RoomData>
    {
        public override void Queue(RoomData data)
        {
            var index = map.roomData.FindIndex(room => room.instanceId == data.instanceId);

            if (index < 0)
            {
                map.roomData.Add(data);
                return;
            }

            map.roomData[index] = new RoomData(data);
        }
    }
}