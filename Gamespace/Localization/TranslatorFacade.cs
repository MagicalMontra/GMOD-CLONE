using Zenject;
using System.Collections.Generic;

namespace Gamespace.Localization
{
    public class TranslatorFacade
    {
        [Inject] private SignalBus _signalBus;
        private List<TranslateStack> _translateStacks = new List<TranslateStack>();

        public void Translate(string clusterTag, string key, OnTranslateCallback callback)
        {
            _translateStacks.Add(new TranslateStack(key).OnTranslated(callback));
            _signalBus.Fire(new TranslateRequestSignal(clusterTag, key));
        }
        public void OnLanguageValueResponse(TranslateResponseSignal signal)
        {
            var keyIndex = _translateStacks.FindIndex(t => t.key == signal.key);

            if (keyIndex > -1)
            {
                _translateStacks[keyIndex].callback.Invoke(signal.value);
                _translateStacks.RemoveAt(keyIndex);
            }
        }
    }
}