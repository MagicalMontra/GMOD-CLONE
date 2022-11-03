namespace Gamespace.Core.Player
{
    public class PlayerLockSignal : IPlayerLockSignal
    {
        public string lockId => _lockId;
        
        private string _lockId;

        public PlayerLockSignal(string lockId)
        {
            _lockId = lockId;
        }
    }
    public class PlayerUnlockSignal : IPlayerUnlockSignal
    {
        public string lockId => _lockId;
        
        private string _lockId;

        public PlayerUnlockSignal(string lockId)
        {
            _lockId = lockId;
        }
    }
}