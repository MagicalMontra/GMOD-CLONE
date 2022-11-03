using Cysharp.Threading.Tasks;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class LocalRoomDeserializationReader : SerializationReader<RoomData>
    {
        public override async UniTask<RoomData> Read(string key)
        {
            await Read();
            var index = map.roomData.FindIndex(data => data.uniqueId == key);
            return index < 0 ? null : map.roomData[index];
        }
        public override async UniTask<RoomData[]> ReadAll()
        {
            await Read();
            return map.roomData.ToArray();
        }
    }
}