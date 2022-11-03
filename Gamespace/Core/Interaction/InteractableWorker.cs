using Gamespace.Core.GameStage;
using Gamespace.Core.Player;
using Zenject;
namespace Gamespace.Core.Interaction
{
    public class InteractableWorker : ITickable, IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IInteractableSelector _interactableSelector;
        [Inject] private InteracableInputWorker _interactableInputWorker;

        private bool _isCorrectMode;
        private bool _isInteracting;

        public void Initialize()
        {
            _interactableInputWorker.Initialize(Interact);
        }
        public void LateDispose()
        {
            _interactableInputWorker.Dispose();
        }
        public void Tick()
        {
            if (!_isCorrectMode)
                return;
            
            _interactableSelector.GetInteractable();
        }
        public void OnGameStageChanged(GameStageSignal signal)
        {
            _isCorrectMode = signal.gameStage == Stage.Play;
            _interactableSelector.DisableAll();
        }
        private void Interact()
        {
            if (!_isCorrectMode)
                return;
            
            _isInteracting = !_isInteracting;
            
            if (_isInteracting)
                _signalBus.AbstractFire(new PlayerLockSignal("Interaction"));
            else
                _signalBus.AbstractFire(new PlayerUnlockSignal("Interaction"));
            
            _interactableSelector.selectedInteractable?.Interact();
        }
    }

}
