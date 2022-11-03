using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.Selection;
using UnityEngine;
using Zenject;

namespace  Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationWorker : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ObjectRotationSettings _settings;
        [Inject] private IRotateAxisIndicator _axisIndicator;
        [Inject] private ObjectRotationExitInputWorker _exitInputWorker;
        [Inject] private ObjectRotationResetInputWorker _resetInputWorker;
        [Inject] private ObjectRotationRotateInputWorker _rotateInputWorker;
        [Inject] private ObjectRotationAxisSwitchInputWorker _switchInputWorker;

        private bool _isEnabled;
        private IRotatable _rotatable;
        private IRotateAxisWorker _selectedAxisWorker;
        private List<IRotateAxisWorker> _axisWorkers = new List<IRotateAxisWorker>();
        
        public void Initialize()
        {
            _axisWorkers.Add(new XRotateEulerAxisWorker());
            _axisWorkers.Add(new YRotateEulerAxisWorker());
            _axisWorkers.Add(new ZRotateEulerAxisWorker());
            _selectedAxisWorker = _axisWorkers[0];
            
            _axisIndicator.Initialize();
            _axisIndicator.SetAxis(0);
            _axisIndicator.SetAngle(Mathf.CeilToInt(_selectedAxisWorker.value));
        }
        public void LateDispose()
        {
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _rotateInputWorker.Dispose();
            _switchInputWorker.Dispose();
            _axisWorkers.Clear();
        }
        public void OnRotationRequestSignal(IRotationRequestSignal signal)
        {
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _rotateInputWorker.Dispose();
            _switchInputWorker.Dispose();
            
            _rotatable = signal.rotatable;
            
            _exitInputWorker.Initialize(Exit);
            _resetInputWorker.Initialize(Reset);
            _rotateInputWorker.Initialize(Rotate);
            _switchInputWorker.Initialize(Switch);

            _axisWorkers[0].Rotate(_rotatable.rotateValue.x);
            _axisWorkers[1].Rotate(_rotatable.rotateValue.y);
            _axisWorkers[2].Rotate(_rotatable.rotateValue.z);
            _axisIndicator.SetAngle(0);

            _isEnabled = true;
            _settings.indicator.SetActive(_isEnabled);
            _signalBus.AbstractFire(new GameStageDisableSignal("RotatingObject"));
        }
        public void OnRotationExitRequested(PlaceableRotateExitRequestSignal responseSignal)
        {
            Exit();
        }
        private void Reset()
        {
            if (!_isEnabled)
                return;

            Quaternion resetQuan = new Quaternion();

            for (int i = 0; i < _axisWorkers.Count; i++)
                resetQuan *= _axisWorkers[i].Reset();

            _rotatable.Rotate(resetQuan);
            _axisIndicator.SetAngle(Mathf.CeilToInt(_selectedAxisWorker.value));
        }
        private void Exit()
        {
            if (!_isEnabled)
                return;
            
            _isEnabled = false;
            
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _rotateInputWorker.Dispose();
            _switchInputWorker.Dispose();
            _settings.indicator.SetActive(_isEnabled);
            _signalBus.AbstractFire(new GameStageEnableSignal("RotatingObject"));
            _signalBus.AbstractFire(new ObjectSelectionEnableSignal("RotatingObject"));
        }
        private void Switch(int index)
        {
            if (!_isEnabled)
                return;
            
            _axisIndicator.SetAxis(index);
            _selectedAxisWorker = _axisWorkers[index];
            _axisIndicator.SetAngle(Mathf.CeilToInt(_selectedAxisWorker.value));
        }
        private void Rotate(float value)
        {
            if (!_isEnabled)
                return;
            
            _rotatable.Rotate(_selectedAxisWorker.Rotate(value));
            _axisIndicator.SetAngle(Mathf.CeilToInt(_selectedAxisWorker.value));
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object)
                return;

            Exit();
        }
    }
}
