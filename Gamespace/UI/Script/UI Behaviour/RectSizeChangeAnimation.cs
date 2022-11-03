using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class RectSizeChangeAnimation : UIAnimation
    {
        [SerializeField] private Vector2 _value;
        [SerializeField] private RectTransform _target;

        private bool _isInitialized;
        private Vector2 _originalValue;

        public override void In(Sequence sequence)
        {
            if (!_isInitialized)
            {
                _originalValue = _target.rect.size;
                _isInitialized = true;
            }

            _sequence.Append(_target.DOSizeDelta(_value, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            if (!_isInitialized)
            {
                _originalValue = _target.rect.size;
                _isInitialized = true;
            }

            _sequence.Append(_target.DOSizeDelta(_originalValue, _duration).SetEase(_ease));
        }
    }
}