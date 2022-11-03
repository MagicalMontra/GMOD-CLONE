namespace Gamespace.Core.Serialization
{
    public class SerializeRequestSignal
    {
        public string sceneName => _sceneName;
        private string _sceneName;

        public SerializeRequestSignal(string sceneName)
        {
            _sceneName = sceneName;
        }
    }
}