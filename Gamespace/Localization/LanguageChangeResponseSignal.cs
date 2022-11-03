namespace Gamespace.Localization
{
    public class LanguageChangeResponseSignal
    {
        public Language language => _language;
        private Language _language;

        public LanguageChangeResponseSignal(Language language)
        {
            _language = language;
        }
    }
}