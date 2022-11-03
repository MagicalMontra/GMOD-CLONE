using System;
using Gamespace.Utilis;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.GameStage
{
    public class GameStageEnterPlayModeInputWorker : InputWorker
    {
        private bool _isPressed;

        [Inject] private GameStageKeyMap _keyMap;
        public override void Initialize(Action action)
        {
            _action = action;
            _keyMap.Editor.PlayMode.started += OnPressed;
            _keyMap.Editor.PlayMode.canceled += OnReleased;
            _keyMap.Editor.PlayMode.Enable();
        }
        public override void Dispose()
        {
            _keyMap.Editor.PlayMode.started -= OnPressed;
            _keyMap.Editor.PlayMode.canceled -= OnReleased;
            _keyMap.Editor.PlayMode.Disable();
        }
    }
    public class GameStageSwitchInputWorker : InputWorker
    {
        private bool _isPressed;

        [Inject] private GameStageKeyMap _keyMap;

        public override void Initialize(Action switchAction)
        {
            _action = switchAction;
            _keyMap.Editor.SwitchEditorMode.started += OnPressed;
            _keyMap.Editor.SwitchEditorMode.canceled += OnReleased;
            _keyMap.Editor.SwitchEditorMode.Enable();
        }
        public override void Dispose()
        {
            _keyMap.Editor.SwitchEditorMode.started -= OnPressed;
            _keyMap.Editor.SwitchEditorMode.canceled -= OnReleased;
            _keyMap.Editor.SwitchEditorMode.Disable();
        }
    }
}