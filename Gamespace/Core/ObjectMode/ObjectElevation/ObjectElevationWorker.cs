using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class ObjectElevationWorker : ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ObjectElevationSettings _settings;
        [Inject] private ObjectElevateExitInputWorker _exitInputWorker;
        [Inject] private ObjectElevateResetInputWorker _resetInputWorker;
        [Inject] private ObjectElevationIndicatorWorker _indicatorWorker;
        [Inject] private ObjectElevateDescendInputWorker _elevationInputWorker;

        private bool _isEnabled;
        private float _elevateValue;
        private IElevatable _elevatable;

        public void OnObjectElevationRequest(IObjectElevationRequestSignal signal)
        {
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _elevationInputWorker.Dispose();
            _elevatable = signal.elevatable;
            _exitInputWorker.Initialize(Exit);
            _resetInputWorker.Initialize(Reset);
            _elevationInputWorker.Initialize(Elevate);
            _elevateValue = signal.elevatable.elevateValue;
            _indicatorWorker.SetText(_elevateValue);
            _isEnabled = true;
            _settings.indicatorPanel.SetActive(_isEnabled);
        }
        public void OnObjectElevationExitRequested(ObjectElevationExitRequestSignal signal)
        {
            Exit();
        }
        private void Exit()
        {
            if (!_isEnabled)
                return;

            _elevateValue = 0;
            _elevatable = null;
            _isEnabled = false;
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _elevationInputWorker.Dispose();
            _settings.indicatorPanel.SetActive(_isEnabled);
            _signalBus.AbstractFire(new ObjectElevationExitRequestSignal());
        }
        private void Reset()
        {
            if (!_isEnabled)
                return;
            
            _elevateValue = 0;
            _elevatable.Elevate(_elevateValue);
            _indicatorWorker.SetText(_elevateValue);
        }
        private void Elevate(float value)
        {
            if (!_isEnabled)
                return;

            if (_elevateValue + value > _settings.elevationLimits)
                _elevateValue = _settings.elevationLimits;
            else if (_elevateValue + value <= 0f)
                _elevateValue = 0;
            else
                _elevateValue += value;
            
            _elevatable.Elevate(_elevateValue);
            _indicatorWorker.SetText(_elevateValue);
        }
        public void LateDispose()
        {
            _elevateValue = 0;
            _elevatable = null;
            _isEnabled = false;
            _exitInputWorker.Dispose();
            _resetInputWorker.Dispose();
            _elevationInputWorker.Dispose();
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object)
                return;

            Exit();
        }
    }
}