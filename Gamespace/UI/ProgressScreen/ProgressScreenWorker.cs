using Cysharp.Threading.Tasks;
using Zenject;

namespace Gamespace.UI.ProgressScreen
{
    public class ProgressScreenWorker
    {
        [Inject] private IProgressScreen.Factory _factory;
        [Inject] private ProgressScreenSettings _settings;
        
        private IProgressScreen progressScreen;
        
        public void OnScreenProgressResponse(ProgressScreenRequestSignal signal)
        {
            progressScreen ??= _factory.Create(_settings.progressScreenPrefab);
            progressScreen.gameObject.SetActive(true);
            progressScreen.Show(signal.current, signal.total, signal.progressText);
        }
        public async void OnScreenProgressCompleted(ProgressScreenCompleteSignal signal)
        {
            progressScreen ??= _factory.Create(_settings.progressScreenPrefab);
            progressScreen.Close(signal.progressText);
            await UniTask.Delay(1000);
            progressScreen.gameObject.SetActive(false);
        }
    }
}