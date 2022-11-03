using System.Collections.Generic;
using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayerLocker
    {
        #region Multiplayer Experiment

        // NOTE: For multiplayer
        // private List<PlayerLockStack> _stacks = new List<PlayerLockStack>();
        //
        // public bool IsLock(string playerId)
        // {
        //     var index = _stacks.FindIndex(stack => stack.playerId == playerId);
        //     
        //     return index < 0 || _stacks[index].lockIds.Count >= 0;
        // }
        // public void Handle(string playerId, string lockerId)
        // {
        //     var index = _stacks.FindIndex(stack => stack.playerId == playerId);
        //     
        //     if (index > -1)
        //     {
        //         if (!_stacks[index].lockIds.Exists(id => id == lockerId))
        //         {
        //             _stacks[index].lockIds.Add(lockerId);
        //             return;
        //         }
        //         
        //         _stacks[index].lockIds.RemoveAll(id => id == lockerId);
        //         
        //         if (_stacks[index].lockIds.Count <= 0)
        //             _stacks.RemoveAt(index);
        //         
        //         return;
        //     }
        //     
        //     _stacks.Add(new PlayerLockStack(playerId, lockerId));
        // }

        #endregion

        public bool IsLock => _stack.count > 0;
        
        [Inject] private DarumaOtoshiStack _stack;
        public void OnPlayerLockRequest(IPlayerLockSignal signal)
        {
            _stack.Add(signal.lockId);
        }
        public void OnPlayerUnlockRequest(IPlayerUnlockSignal signal)
        {
            _stack.Hit(signal.lockId);
        }
    }
}