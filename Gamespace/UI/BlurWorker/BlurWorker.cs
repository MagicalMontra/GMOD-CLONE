using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Zenject;

namespace Gamespace.UI
{
    public class BlurWorker : IInitializable, ILateDisposable
    {
        [Inject] private BlurStackSettings _settings;
        [Inject] private BlurStackWorker.Factory _factory;

        private List<BlurStackWorker> _stackWorkers = new List<BlurStackWorker>();
        public void OnBlurBeginRequest(BlurBeginRequestSignal signal)
        {
            var index = _stackWorkers.FindIndex(stack => stack.name == signal.name);
            
            if (index < 0)
                return;
            
            _stackWorkers[index].Push(signal.target, signal.duration, signal.ease);
        }
        public void OnBlurCancelRequest(BlurCancelRequestSignal signal)
        {
            var index = _stackWorkers.FindIndex(stack => stack.name == signal.name);
            
            if (index < 0)
                return;
            
            _stackWorkers[index].Pop(signal.duration, signal.ease);
        }
        public void Initialize()
        {
            for (int i = 0; i < _settings.blurConfigs.Count; i++)
                _stackWorkers.Add(_factory.Create(_settings.blurConfigs[i]));
        }

        public void LateDispose()
        {
            _stackWorkers.Clear();
        }
    }
}
