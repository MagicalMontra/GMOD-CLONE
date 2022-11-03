using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveToAnimation : UIAnimation
    {
        [SerializeField] private Transform _moveToTarget;
        [SerializeField] private Transform _targetToMove;
        [SerializeField] private bool _rectMode;
        
        private Vector2 _originalPos;
        private bool _hasOriginal;
        
        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _originalPos = _rectMode ? _targetToMove.GetComponent<RectTransform>().anchoredPosition : (Vector2)_targetToMove.localPosition;
            }
            
            if (!_rectMode)
                sequence.Append(_targetToMove.DOLocalMove(_moveToTarget.position, _duration).SetEase(_ease));
            else
                sequence.Append(_targetToMove.GetComponent<RectTransform>().DOAnchorPos(_moveToTarget.GetComponent<RectTransform>().anchoredPosition, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            if (!_rectMode)
                sequence.Append(_targetToMove.DOLocalMove(_originalPos, _duration).SetEase(_ease));
            else
                sequence.Append(_targetToMove.GetComponent<RectTransform>().DOAnchorPos(_originalPos, _duration).SetEase(_ease));
        }
        public override void Reset()
        {
            if (!_rectMode)
                _targetToMove.localPosition = _originalPos;
            else
                _targetToMove.GetComponent<RectTransform>().anchoredPosition = _originalPos;
        }
    }
}