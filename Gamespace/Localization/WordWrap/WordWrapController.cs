using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class WordWrapController
    {
        [Inject] private ITokenizer.Factory _tokenFactory;
        [Inject] private IWordWrapWorker.Factory _workerFactory;
        [Inject] private BoxWidthCalculator _boxWidthCalculator;

        private ITokenizer _tokenizer;
        private IWordWrapWorker _currentWorker;

        public void OnLanguageChangeResponse(LanguageChangeResponseSignal signal)
        {
            _tokenizer = _tokenFactory.Create(signal.language);
            _currentWorker = _workerFactory.Create(_tokenizer, signal.language);
        }
        public void OnWordWrapRequest(WordWrapRequestSignal signal)
        {
            var boxWidth = _boxWidthCalculator.GetBoxWidth(signal.target.rectTransform);
            var wrappedWords = _currentWorker.Wrap(signal.text, boxWidth, signal.target.font.sourceFontFile);
            signal.target.text = wrappedWords;
        }
    }
}