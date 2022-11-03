using UnityEngine;

namespace Gamespace.Core.Blueprint.Room
{
    public interface IRoomSelector
    {
        RoomBase Select(Vector2 selectPosition);
    }
}
