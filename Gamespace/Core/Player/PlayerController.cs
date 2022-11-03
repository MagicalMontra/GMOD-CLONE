using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayerController : IFixedTickable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerLocker _playerLocker;
        [Inject] private PlayerPoolHandler _poolHandler;

        private bool _isActive;
        
        public void OnPlayerSpawnRequest(PlayerSpawnRequestSignal signal)
        {
            if (!_isActive)
                return;
            
            _poolHandler.Spawn(signal.position);
            _signalBus.Fire(new PlayerInitializedSignal(_poolHandler.player));
            _poolHandler.player.inputSource.IsEnabled = true;
            _poolHandler.player.gameCore.IsCursorVisible = false;
        }
        public void OnPlayerDespawnRequest(PlayerDespawnRequestSignal signal)
        {
            if (!_isActive)
                return;
            
            _poolHandler.Despawn();
        }
        public void OnForceLookAtRequest(IPlayerLookAtRequestSignal signal)
        {
            // _poolHandler.player.camera.transform.LookAt(signal.position);
        }
        public void OnStateChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play)
            {
                _isActive = true;
                return;
            }

            _isActive = false;
            _poolHandler.Despawn();
        }
        public void FixedTick()
        {
            if (!_isActive)
                return;
            
            if (_poolHandler.player.inputSource.IsEnabled != !_playerLocker.IsLock)
                _poolHandler.player.inputSource.IsEnabled = !_playerLocker.IsLock;

            if (_poolHandler.player.gameCore.IsCursorVisible != _playerLocker.IsLock)
                _poolHandler.player.gameCore.IsCursorVisible = _playerLocker.IsLock;

            _poolHandler.player.SetEnabled = !_playerLocker.IsLock;
        }
    }
}