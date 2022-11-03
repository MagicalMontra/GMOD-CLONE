using System.Collections;

namespace Gamespace.Core.Serialization
{
    public interface ISerializable<TContract>
    {
        TContract Serialize();
        void Deserialize(TContract data);
    }
}
