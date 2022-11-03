using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gamespace.UI
{
    public class ShrinkingLoopAnimation : UIAnimation
    {
        [SerializeField] private int _subSequenceCount = 3;
        [SerializeField] private float _maxRange;
        [SerializeField] private Transform _target;

        private Vector3 _originalScale;
        private bool _isInit;

        public override void In(Sequence sequence)
        {
            if (!_isInit)
            {
                _originalScale = _target.localScale;
                _isInit = true;
            }

            for (int i = 0; i < _subSequenceCount; i++)
            {
                sequence.Append(_target.DOScale(_originalScale * Random.Range(1, _maxRange), 
                    _duration / _subSequenceCount).SetEase(_ease));
            }
            
            sequence.Append(_target.DOScale(_originalScale, _duration / (_subSequenceCount + 1)).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            Reset();
        }

        public override void Reset()
        {
            _target.localScale = _originalScale;
        }
    }
}