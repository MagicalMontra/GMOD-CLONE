namespace Gamespace.Core.Audio
{
    public class AudioClipListResponseSignal
    {
        public string[] clipNames;
        private string[] _clipNames;

        public AudioClipListResponseSignal(string[] clipNames)
        {
            _clipNames = clipNames;
        }
    }
}