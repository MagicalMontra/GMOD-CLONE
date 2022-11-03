using System.Collections.Generic;

namespace Gamespace.Core.Audio
{
    public class AudioClipRequestSignal
    {
        public string name => _name;
        private string _name;
        public AudioClipRequestSignal(string name)
        {
            _name = name;
        }
    }
}