using TMPro;

namespace Gamespace.Localization
{
    public class WordWrapRequestSignal
    {
        public string text => _text;
        public TextMeshProUGUI target => _target;

        private string _text;
        private TextMeshProUGUI _target;
        
        public WordWrapRequestSignal(string text, TextMeshProUGUI target)
        {
            _text = text;
            _target = target;
        }
    }
}