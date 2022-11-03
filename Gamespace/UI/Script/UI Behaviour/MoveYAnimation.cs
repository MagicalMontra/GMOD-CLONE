using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveYAnimation : UIAnimation
    {
        [SerializeField] private float _targetY = 1f;
        [SerializeField] private bool _rectMode;
        [SerializeField] private Transform _target;

        private float _originalY;
        private bool _hasOriginal;
        
        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _originalY = _rectMode ? _target.GetComponent<RectTransform>().anchoredPosition.y : _target.localPosition.y;
            }

            if (!_rectMode)
                sequence.Append(_target.DOLocalMoveY(_targetY, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPosY(_targetY, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            if (!_rectMode)
                sequence.Append(_target.DOLocalMoveY(_originalY, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOLocalMoveY(_originalY, _duration).SetEase(_ease));
        }
        public override void Reset()
        {
            var targetPos = _target.localPosition;
            _target.localPosition = new Vector3(targetPos.x, _originalY, targetPos.z);
        }
    }
}