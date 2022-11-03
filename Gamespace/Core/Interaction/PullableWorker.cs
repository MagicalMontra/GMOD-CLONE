using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.Interaction
{
    public class PullableWorker : IInitializable, ILateDisposable
    {
        [Inject] private IInteractableSelector _interactableSelector;
        [Inject] private PullableInputWorker _pullableInputWorker;
        
        private bool _isCorrectMode;

        private IPullable _pullable;
        public void Initialize()
        {
            _pullableInputWorker.Initialize(AssignPullValue);
        }
        public void LateDispose()
        {
            _pullableInputWorker.Dispose();
        }
        public void OnGameStageChanged(GameStageSignal signal)
        {
            _isCorrectMode = signal.gameStage == Stage.Play;
        }
        private void AssignPullValue(float value)
        {
            if (!_isCorrectMode)
                return;

            if (_interactableSelector.selectedInteractable is null)
                return;

            _pullable = _interactableSelector.selectedInteractable as IPullable;
            _pullable?.Pull(value);
        }

    }
}