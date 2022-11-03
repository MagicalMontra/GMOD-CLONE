using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class LanguageController : IInitializable
    {
        [Inject] private LanguageDataLoader _dataLoader;
        [Inject] private LanguageSettings _settings;
        [Inject] private SignalBus _signalBus;

        private Language _currentLanguage;
        private const string _key = "MACHINE_LANGUAGE";

        public void Initialize()
        {
            var hasKey = PlayerPrefs.HasKey(_key);
            if (!hasKey)
            {
                _currentLanguage = _settings.defaultLanguage;
                _signalBus.Fire(new LanguageChangeResponseSignal(_currentLanguage));
                return;
            }

            var key = PlayerPrefs.GetString(_key);
            var index = _settings.avaliableLanguages.FindIndex(language => language.name == key);

            if (index < 0)
            {
                _currentLanguage = _settings.defaultLanguage;
                return;
            }

            _currentLanguage = _settings.avaliableLanguages[index]; 
            _signalBus.Fire(new LanguageChangeResponseSignal(_currentLanguage));
        }
        public void OnLanguageModeRequest(LanguageRequestSignal signal)
        {
            _signalBus.Fire(new LanguageResponseSignal());
        }
        public void OnLanguageChangeRequest(LanguageChangeRequestSignal signal)
        {
            var index = _settings.avaliableLanguages.FindIndex(language => language.name == signal.key);

            if (index < 0)
            {
                _currentLanguage = _settings.defaultLanguage;
                return;
            }

            _currentLanguage = _settings.avaliableLanguages[index];
            PlayerPrefs.SetString(_key, _currentLanguage.name);
            PlayerPrefs.Save();
            _signalBus.Fire(new LanguageChangeResponseSignal(_currentLanguage));
        }
        public void OnTranslateRequest(TranslateRequestSignal signal)
        {
            TranslateRequest(signal).Forget();
        }
        private async UniTaskVoid TranslateRequest(TranslateRequestSignal signal)
        {
            var cluster = _settings.clusters.Find(c => c.tag == signal.clusterTag);

            if (cluster == null)
            {
                _signalBus.Fire(new TranslateResponseSignal(signal.key, signal.key));
                return;
            }

            await UniTask.WaitUntil(() => _currentLanguage != null);

            var clusterMode = cluster.list.Find(list => list.name == _currentLanguage.name);
            var value = _dataLoader.GetValue(clusterMode, signal.key, signal.args);

            _signalBus.Fire(new TranslateResponseSignal(signal.key, value));
        }
    }
}
