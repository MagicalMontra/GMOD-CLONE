using Zenject;

namespace Gamespace.Localization
{
    public interface ITranslator : IInitializable
    {
        void Translate(string key, OnTranslateCallback callback);
        void OnLanguageValueResponse(TranslateResponseSignal signal);
    }
}