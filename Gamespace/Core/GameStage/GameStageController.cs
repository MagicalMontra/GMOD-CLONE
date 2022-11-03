using Gamespace.Utilis;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.GameStage
{
    public class GameStageController : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private GameStageEnableStack _enableStack;
        [Inject] private GameStageSwitchInputWorker _switchInputWorker;
        [Inject] private GameStageEnterPlayModeInputWorker _playModeGameStageEnterPlayModeInputWorker;

        private Stage _gameStage;

        private void SwitchEditorMode()
        {
            if (!_enableStack.isEnabled)
                return;
            
            _gameStage = _gameStage switch
            {
                Stage.Object => Stage.BluePrint,
                Stage.BluePrint => Stage.Object,
                _ => _gameStage
            };

            _signalBus.Fire(new GameStageSignal(_gameStage));
        }
        private void SwitchPlayMode()
        {
            if (!_enableStack.isEnabled)
                return;
            
            if (_gameStage == Stage.Object || _gameStage == Stage.BluePrint)
            {
                _gameStage = Stage.Play;
                _signalBus.Fire(new GameStageSignal(_gameStage));
            }
            else
            {
                _gameStage = Stage.Object;
                _signalBus.Fire(new GameStageSignal(_gameStage));
            }
        }
        public void OnGameStageChanged(Stage stage)
        {
            if (_gameStage == stage)
                return;
        
            _gameStage = stage;
            _signalBus.Fire(new GameStageSignal(_gameStage));
        }
        public void GetStage(GetStageSignal signal)
        {
            _signalBus.Fire(new GameStageSignal(_gameStage));
        }
        public void Initialize()
        {
            _switchInputWorker.Initialize(SwitchEditorMode);
            _playModeGameStageEnterPlayModeInputWorker.Initialize(SwitchPlayMode);
        }
        public void LateDispose()
        {
            _switchInputWorker.Dispose();
        }
    }
}