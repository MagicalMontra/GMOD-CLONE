using System.Reflection;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Selection;
using Gamespace.Core.Player;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionPropertyWorker : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ActionSettings _settings;
        [Inject] private IActionPropertyPanelSetActive _panelSetActive;
        [Inject] private ActionPropertyExitInputWorker _exitInputWorker;
        [Inject] private SliderActionPropertyElementPoolWorker _sliderPoolWorker;
        [Inject] private InputFieldActionPropertyElementPoolWorker _inputFieldPoolWorker;

        private bool _isEnabled;
        
        public void OnActionPropertyRequest(ActionPropertyRequestSignal signal)
        {
            _signalBus.AbstractFire(new ObjectSelectionDisableSignal("Action Property Panel"));
            _signalBus.AbstractFire(new PlayerLockSignal("Action Property Panel"));
            
            _panelSetActive.SetActive(true);
            _settings.actionPropertyTitle.text = signal.name;
            
            _settings.pageGroup.SetActive(signal.variables.Length > 4);
            
            for (int i = 0; i < signal.variables.Length; i++)
            {
                ActionPropertyUIElement element;
                var instance = signal.variables[i];
                var filedInfo = signal.variables[i].GetField();
                var fieldType = signal.variables[i].fieldType;

                element = SelectPool(instance, filedInfo, fieldType);
                
                if (element is null)
                    continue;
                
                element.SetName(signal.fieldNames[i]);
            }

            _isEnabled = true;
        }
        public void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object)
                return;
            
            Exit();
        }
        private ActionPropertyUIElement SelectPool(ActionVariable variableInstance, FieldInfo fieldInfo, FieldType fieldType)
        {
            return fieldType switch
            {
                FieldType.Slider => _sliderPoolWorker.Spawn(variableInstance, fieldInfo),
                FieldType.InputField => _inputFieldPoolWorker.Spawn(variableInstance, fieldInfo),
                _ => null
            };
        }
        private void Exit()
        {
            _sliderPoolWorker.Despawn();
            _inputFieldPoolWorker.Despawn();
            _panelSetActive.SetActive(false);
            _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Action Property Panel"));
            _signalBus.AbstractFire(new PlayerUnlockSignal("Action Property Panel"));

            _isEnabled = false;
        }
        public void Initialize()
        {
            if (_panelSetActive.isEnabled)
                _panelSetActive.SetActive(false);
            
            _exitInputWorker.Initialize(Exit);
            _settings.backButton.onClick.RemoveAllListeners();
            _settings.backButton.onClick.AddListener(Exit);
        }
        public void LateDispose()
        {
            _exitInputWorker.Dispose();
            _settings.backButton.onClick.RemoveAllListeners();
        }
    }

}