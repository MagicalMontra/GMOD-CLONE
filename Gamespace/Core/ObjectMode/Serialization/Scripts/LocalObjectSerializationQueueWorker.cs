using Cysharp.Threading.Tasks;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class LocalObjectSerializationQueueWorker : SerializationQueueWorker<ObjectData>
    {
        public override void Queue(ObjectData data)
        {
            var index = map.objectData.FindIndex(d => d.instanceId == data.instanceId);

            if (index < 0)
            {
                map.objectData.Add(data);
                return;
            }

            map.objectData[index] = new ObjectData(data);
        }
    }
}