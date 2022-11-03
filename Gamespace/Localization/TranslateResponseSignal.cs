namespace Gamespace.Localization
{
    public class TranslateResponseSignal
    {
        public string key => _key;
        public string value => _value;
        private string _key;
        private string _value;

        public TranslateResponseSignal(string key, string value)
        {
            _key = key;
            _value = value;
        }
    }
}