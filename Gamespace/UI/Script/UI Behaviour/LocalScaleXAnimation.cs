using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class LocalScaleXAnimation : UIAnimation
    {
        [SerializeField] private float _startX;
        [SerializeField] private float _targetX = 1f;
        [SerializeField] private GameObject _target;

        public override void In(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScaleX(_startX, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScaleX(_targetX, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScaleX(_targetX, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScaleX(_startX, _duration).SetEase(_ease));
        }
        protected override void OnEnable()
        {
            base.OnEnable();

            Reset();
        }
        public override void Reset()
        {
            var targetScale = _target.transform.localScale;
            _target.transform.localScale = new Vector3(_startX, targetScale.y, targetScale.z);
        }
    }
}