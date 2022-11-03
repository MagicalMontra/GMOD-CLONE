using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class LocalScaleYAnimation : UIAnimation
    {
        [SerializeField] private float _startY;
        [SerializeField] private float _targetY = 1f;
        [SerializeField] private GameObject _target;

        public override void In(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScaleY(_startY, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScaleY(_targetY, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScaleY(_targetY, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScaleY(_startY, _duration).SetEase(_ease));
        }
        public override void Reset()
        {
            var targetScale = _target.transform.localScale;
            _target.transform.localScale = new Vector3(targetScale.x, _startY, targetScale.z);
        }
    }
}