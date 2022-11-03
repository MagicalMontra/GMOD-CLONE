using Cysharp.Threading.Tasks;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class LocalObjectSerializationReader : SerializationReader<ObjectData>
    {
        public override async UniTask<ObjectData> Read(string key)
        {
            await Read();
            var index = map.objectData.FindIndex(data => data.uniqueId == key);
            return index < 0 ? null : map.objectData[index];
        }
        public override async UniTask<ObjectData[]> ReadAll()
        {
            await Read();
            return map.objectData.ToArray();
        }
    }
}