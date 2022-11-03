namespace Gamespace.Core.Audio
{
    public class AudioClipResponseSignal
    {
        public AudioData data => _data;
        private AudioData _data;
        public AudioClipResponseSignal(AudioData data)
        {
            _data = data;
        }
    }
}