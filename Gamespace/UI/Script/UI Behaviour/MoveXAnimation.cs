using System;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveXAnimation : UIAnimation
    {
        [SerializeField] private bool _rectMode;
        [SerializeField] private float _targetX = 1f;
        [SerializeField] private Transform _target;

        private float _originalX;
        private bool _hasOriginal;
        
        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _originalX = _rectMode ? _target.GetComponent<RectTransform>().anchoredPosition.x : _target.localPosition.x;
            }

            if (!_rectMode)
                sequence.Append(_target.DOLocalMoveX(_targetX, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPosX(_targetX, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            if (!_rectMode)
                sequence.Append(_target.DOLocalMoveX(_originalX, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPosX(_originalX, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            var targetPos = _target.localPosition;
            _target.localPosition = new Vector3(_originalX, targetPos.y, targetPos.z);
        }
    }
}