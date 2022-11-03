using System;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class ExpandEnableAnimation : UIAnimation
    {
        [SerializeField] private Transform _target;
        private Vector3 _originalScale;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _originalScale = _target.localScale;
            _target.localScale = Vector3.zero;
        }
        public override void In(Sequence sequence)
        {
            sequence.AppendCallback(() => _target.localScale = Vector3.zero);
            sequence.Append(_target.DOScale(_originalScale, _duration));
            sequence.SetEase(_ease);
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendCallback(() => _target.localScale = _originalScale);
            sequence.Append(_target.DOScale(Vector3.zero, _duration));
            sequence.SetEase(_ease);
        }
        public override void Reset()
        {
            _target.localScale = Vector3.zero;
        }
    }
}