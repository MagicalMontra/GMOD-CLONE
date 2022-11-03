namespace Gamespace.Core.Player
{
    public interface IPlayerLockSignal
    {
        string lockId { get; }
    }
    public interface IPlayerUnlockSignal
    {
        string lockId { get; }
    }
    
}