using System;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class ZPosEnableAnimation : UIAnimation
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _startPos;
        private float _originalPos;

        void Start()
        {
            var targetPos = _target.localPosition;
            _originalPos = targetPos.z;
            _target.localPosition = new Vector3(targetPos.x, targetPos.y, _startPos);
        }
        public override void In(Sequence sequence)
        {
            sequence.AppendCallback(() =>
            {
                var targetPos = _target.localPosition;
                _target.localPosition = new Vector3(targetPos.x, targetPos.y, _startPos);
            });
            sequence.Append(_target.DOLocalMoveZ(_originalPos, _duration));
            sequence.SetEase(_ease);
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendCallback(() => _target.localPosition = Vector3.zero);
            sequence.Append(_target.DOLocalMoveZ(_startPos, _duration));
            sequence.SetEase(_ease);
        }

        public override void Reset()
        {
            var targetPos = _target.localPosition;
            _target.localPosition = new Vector3(targetPos.x,  targetPos.y, _originalPos);
        }
    }
}