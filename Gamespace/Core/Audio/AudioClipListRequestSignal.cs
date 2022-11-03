namespace Gamespace.Core.Audio
{
    public class AudioClipListRequestSignal
    {
        public string searchName => _searchName;
        private string _searchName;

        public AudioClipListRequestSignal(string searchName)
        {
            _searchName = searchName;
        }
    }
}