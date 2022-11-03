using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.Player
{
    public class EditorPlayerController : IFixedTickable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlayerLocker _playerLocker;
        [Inject] private EditorPlayerSettings _settings;
        [Inject] private EditorPlayerPoolHandler _poolHandler;

        private bool _isActive;
        
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
        public void OnEditorSpawnRequest(EditorEnableRequestSignal signal)
        {
            if (!_isActive)
                return;

            _poolHandler.Spawn(signal.position);
            _signalBus.Fire(new EditorInitializedSignal(_poolHandler.player));
            _poolHandler.player.inputSource.IsEnabled = true;
            _poolHandler.player.gameCore.IsCursorVisible = false;
        }
        public void OnEditorDespawnRequest(EditorDisableRequestSignal signal)
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
            if (signal.gameStage == Stage.Play || signal.gameStage == Stage.Uninitialized)
            {
                _isActive = false;
                _poolHandler.Despawn();
                return;
            }

            _isActive = true;
            _settings.spawnPoint.SpawnEditor();

            // if (signal.GameMode == GameMode.Play || signal.GameMode == GameMode.Uninitialized)
            // {
            //     _isActive = false;
            //     _signalBus.Fire(new EditorDisableRequestSignal());
            //     return;
            // }

            // _isActive = true;
            // _signalBus.Fire(new EditorEnableRequestSignal(_settings.spawnPoint.transform.position));
        }
    }
}