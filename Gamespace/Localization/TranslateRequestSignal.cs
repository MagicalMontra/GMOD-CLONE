namespace Gamespace.Localization
{
    public class TranslateRequestSignal
    {
        public string clusterTag => _clusterTag;
        public string key => _key;
        public object[] args => _args;
        private object[] _args;
        private string _key;
        private string _clusterTag;

        public TranslateRequestSignal(string clusterTag, string key, params object[] args)
        {
            _clusterTag = clusterTag;
            _key = key;
            _args = args;
        }
    }
}