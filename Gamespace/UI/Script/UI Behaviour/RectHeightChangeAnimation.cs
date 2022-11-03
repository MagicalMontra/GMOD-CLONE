using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class RectHeightChangeAnimation : UIAnimation
    {
        [SerializeField] private float _value;
        [SerializeField] private RectTransform _target;

        private float _originalValue = -99;

        public override void In(Sequence sequence)
        {
            if (_originalValue <= -99)
            {
                _originalValue = _target.rect.height;
            }

            _sequence.Append(DOTween.To(() => _target.sizeDelta.y, x => _target.sizeDelta = new Vector2(_target.sizeDelta.x, x), _value, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            if (_originalValue <= -99)
            {
                _originalValue = _target.rect.height;
            }

            _sequence.Append(DOTween.To(() => _target.sizeDelta.y, x => _target.sizeDelta = new Vector2(_target.sizeDelta.x, x), _originalValue, _duration).SetEase(_ease));
        }
    }
}