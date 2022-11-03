using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveToYAnimation : UIAnimation
    {
        [SerializeField] private bool _rectMode;
        [SerializeField] private float _startY;
        [SerializeField] private float _targetY = 1f;
        [SerializeField] private Transform _target;

        private float _originalY = -99;

        private void Awake()
        {
            if (!_rectMode)
            {
                _target.DOLocalMoveY(_startY, 0.01f);
            }
            else
            {
                _target.GetComponent<RectTransform>().DOAnchorPosY(_startY, 0.01f);
            }
        }

        public override void In(Sequence sequence)
        {
            if (_originalY <= -99)
            {
                _originalY = _rectMode ? _target.GetComponent<RectTransform>().anchoredPosition.x : _target.localPosition.x;
            }

            if (!_rectMode)
            {
                sequence.Append(_target.DOLocalMoveY(_targetY, _duration).SetEase(_ease));
            }
            else
            {
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPosY(_targetY, _duration).SetEase(_ease));
            }
        }
        public override void Out(Sequence sequence)
        {
            if (!_rectMode)
                sequence.Append(_target.DOLocalMoveY(_startY, _duration).SetEase(_ease));
            else
                sequence.Append(_target.GetComponent<RectTransform>().DOAnchorPosY(_startY, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            var targetPos = _target.localPosition;
            _target.localPosition = new Vector3(targetPos.x, _startY, targetPos.z);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Reset();
        }
    }
}