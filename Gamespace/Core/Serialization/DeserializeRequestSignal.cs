namespace Gamespace.Core.Serialization
{
    public class DeserializeRequestSignal
    {
        public string sceneName => _sceneName;
        private string _sceneName;

        public DeserializeRequestSignal(string sceneName)
        {
            _sceneName = sceneName;
        }
    }
}