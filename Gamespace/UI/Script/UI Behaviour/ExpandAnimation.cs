using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    [Serializable]
    public class ExpandAnimation : UIAnimation
    {
        [SerializeField] private float _magnitude = 1f;
        [SerializeField] private Transform _target;
        
        private Vector3 _originalScale;
        private bool _hasOriginal;

        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _originalScale = _target.localScale;
            }
            
            sequence.AppendCallback(Reset);
            sequence.Append(_target.DOScale(_target.localScale * _magnitude, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.DOScale(_originalScale, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            _target.DOScale(Vector3.one, 0.01f);
        }
    }
}