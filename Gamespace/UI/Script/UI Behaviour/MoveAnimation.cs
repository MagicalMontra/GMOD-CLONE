using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveAnimation : UIAnimation
    {
        [SerializeField] private bool _rectMode;
        [SerializeField] private Vector3 _targetVector;
        [SerializeField] private Transform _target;

        private Vector3 _original;
        private bool _hasOriginal;
        
        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _original = _rectMode ? new Vector3(_target.GetComponent<RectTransform>().anchoredPosition.x, _target.GetComponent<RectTransform>().anchoredPosition.y, 0) : _target.localPosition;
            }

            if (!_rectMode)
                sequence.Append(_target.DOLocalMove(_targetVector, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPos(_targetVector, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            if (!_rectMode)
                sequence.Append(_target.DOLocalMove(_original, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPos(_original, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            _target.localPosition = _original;
        }
    }
}