using Zenject;

namespace Gamespace.UI
{
    public class LoadingScreenWorker
    {
        [Inject] private LoadingScreen.Factory _factory;
        [Inject] private LoadingScreenSettings _settings;

        private LoadingScreen _currentScreen;

        public void OnLoadingScreenRequested(LoadingScreenRequestSignal signal)
        {
            _currentScreen ??= _factory.Create(_settings.loadingScreenPrefab);
            _currentScreen.Push();
        }
        public void OnLoadingScreenCancelled(LoadingScreenCancelSignal signal)
        {
            if (ReferenceEquals(_currentScreen, null))
                return;
            
            _currentScreen.Pop();
        }
    }
}