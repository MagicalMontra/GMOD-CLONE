using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gamespace.UI
{
    public class TextChangeAnimation : UIAnimation
    {
        [SerializeField] private string _stringToChange;
        [SerializeField] private TextMeshProUGUI _text;
        private string _originalString;
        public override void In(Sequence sequence)
        {
            if (string.IsNullOrEmpty(_originalString))
                _originalString = _text.text;

            sequence.AppendInterval(_duration);
            sequence.AppendCallback(() => _text.text = _stringToChange);
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendInterval(_duration);
            sequence.AppendCallback(() => _text.text = _originalString);
        }
        public override void Reset()
        {
            _text.text = _originalString;
        }
    }
}