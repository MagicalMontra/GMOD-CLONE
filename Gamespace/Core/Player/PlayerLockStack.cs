using System.Collections.Generic;

namespace Gamespace.Core.Player
{
    public class PlayerLockStack
    {
        public string playerId;
        public List<string> lockIds = new List<string>();

        public PlayerLockStack(string playerId, string lockerId)
        {
            this.playerId = playerId;
        }
    }
}