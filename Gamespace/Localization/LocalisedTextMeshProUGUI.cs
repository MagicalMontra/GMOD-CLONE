using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalisedTextMeshProUGUI : MonoBehaviour
    {
        public string text
        {
            get => _textMesh.text;
            set => _textMesh.text = value;
        }

        public string key
        {
            get => _localisedString.key;
            set => _localisedString.key = value;
        }

        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private LocalisedString _localisedString;
        
        private bool _isUpdating;
        private bool _isInjected;
        private bool _isLanguageInitialized;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _isInjected = true;
            _signalBus.Subscribe<TranslateResponseSignal>(OnTranslated);
            _signalBus.Subscribe<LanguageResponseSignal>(OnLanguageResponse);
            _signalBus.Subscribe<LanguageChangeResponseSignal>(OnLanguageChangeResponse);

            RequestTranslation();
        }
        public void RequestTranslation()
        {
            if (!_isInjected)
                return;

            if (_localisedString.args.Count <= 0)
                _signalBus?.Fire(new TranslateRequestSignal(_localisedString.clusterTag, key));
            else
                _signalBus?.Fire(new TranslateRequestSignal(_localisedString.clusterTag, key, _localisedString.args));
        }
        private void OnLanguageResponse(LanguageResponseSignal signal)
        {
            RequestTranslation();
        }
        private void OnLanguageChangeResponse(LanguageChangeResponseSignal signal)
        {
            if (_localisedString.args.Count <= 0)
                _signalBus?.Fire(new TranslateRequestSignal(_localisedString.clusterTag, key));
            else
                _signalBus?.Fire(new TranslateRequestSignal(_localisedString.clusterTag, key, _localisedString.args));
        }
        private void OnTranslated(TranslateResponseSignal signal)
        {
            if (_localisedString.key != signal.key)
                return;

            _textMesh.text = signal.value;
            _signalBus.Fire(new WordWrapRequestSignal(signal.value, _textMesh));
        }
    }
}