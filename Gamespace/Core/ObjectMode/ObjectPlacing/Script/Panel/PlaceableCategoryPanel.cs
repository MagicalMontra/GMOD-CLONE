using System.Threading.Tasks;
using Gamespace.Core.GameStage;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableCategoryPanel : IInitializable, ILateDisposable, IOnGameStageChange
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlaceableObjectUIButtonPool _pool;
        [Inject] private PlaceableObjectPanelSettings _settings;
        [Inject] private PlaceableObjectPanelOpenInputWorker _openInputWorker;
        [Inject] private PlaceableObjectPanelCloseInputWorker _closeInputWorker;

        private bool _isEnabled;
        private bool _isOpened;
        
        public void OnObjectPanelPageChanged(ICategoryPanelChangeSignal signal)
        {
            _pool.Dispose();
            
            for (int i = 0; i < signal.category.count; i++)
                _pool.Get(signal.category.GetObject(i));
        }
        public void OnPlaceablePanelOpened(IPlaceablePanelOpenSignal signal)
        {
            if (!_isEnabled)
                return;
            
            _isOpened = true;
            _settings.panel.SetActive(true);
        }
        public void OnPlaceablePanelCloseSignal(IPlaceablePanelCloseSignal signal)
        {
            _isOpened = false;
            _settings.panel.SetActive(false);
        }
        private async void Open()
        {
            if (!_isEnabled)
                return;

            if (_isOpened) return;
            
            await Task.Delay(100);
            _signalBus.AbstractFire(new PlaceableObjectPanelOpenSignal("", "SelectObject"));
        }
        private void Close()
        {
            if (_isOpened)
                _signalBus.AbstractFire(new PlaceableObjectPanelCancelSignal("", "SelectObject"));
        }
        public void Initialize()
        {
            _openInputWorker.Initialize(Open);
            _closeInputWorker.Initialize(Close);
        }
        public void LateDispose()
        {
            _openInputWorker.Dispose();
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            _isEnabled = signal.gameStage == Stage.Object;

            if (!_isEnabled)
                Close();
        }
    }
}