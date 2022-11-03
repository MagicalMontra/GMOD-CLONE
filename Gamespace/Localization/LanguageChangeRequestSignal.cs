namespace Gamespace.Localization
{
    public class LanguageChangeRequestSignal
    {
        public string key => _key;
        private string _key;

        public LanguageChangeRequestSignal(string key)
        {
            _key = key;
        }
    }
}