using Gamespace.Core.Actions;
using Zenject;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Elevation;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.Rotation;
using Gamespace.Core.ObjectMode.Selection;
using Gamespace.UI;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectModeIndicatorWorker
    {
        [Inject] private ObjectModeSettings _settings;

        private bool _isCorrectMode;

        private void SetActive(bool enabled)
        {
            _settings.indicatorPanel.SetActive(_isCorrectMode && enabled);
        }
        public void OnObjectSelectionEnabled(IObjectSelectionEnableSignal signal)
        {
            SetActive(true);
        }
        public void OnObjectSelectionDisabled(IObjectSelectionDisableSignal signal)
        {
            SetActive(false);
        }
        public void OnCircleWheelOpened(ICircleWheelOpenSignal signal)
        {
            SetActive(false);
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            _isCorrectMode = signal.gameStage == Stage.Object;
            SetActive(signal.gameStage == Stage.Object);
        }
    }
}