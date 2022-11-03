using Gamespace.Localization;
using Zenject;

namespace Gamespace.Network.RestAPI
{
    public class NetOperationErrorTranslator
    {
        [Inject] private NetworkSettings _settings;
        [Inject] private TranslatorFacade _translatorFacade;

        public void Translate(NetOperationError error)
        {
            _translatorFacade.Translate(_settings.languageCluster, $"Code {error.statusCode}", (code) =>
            {
                _translatorFacade.Translate(_settings.languageCluster, error.error, (title) =>
                {
                    error.error = $"{title} {code}";
                });
            });

            _translatorFacade.Translate(_settings.languageCluster, error.message, (message) => error.message = message);
        }
    }
}