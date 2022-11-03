using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class FadeLoopAnimation : UIAnimation
    {
        [SerializeField] [Range(0.1f, 1f)] private float _minMag;
        [SerializeField] [Range(0.1f, 1f)] private float _maxMag;
        [SerializeField] private CanvasGroup _target;
        private float _alpha1;

        public override void In(Sequence sequence)
        {
            _alpha1 = Random.Range(_minMag, _maxMag);
            var alpha2 = Random.Range(_maxMag, 1);

            sequence.Append(
                _target.DOFade(_alpha1, _duration / 2).SetEase(_ease));
            sequence.Append(
                _target.DOFade(alpha2, _duration / 2).SetEase(_ease));
            sequence.AppendCallback(() => _target.alpha = alpha2);
        }
        public override void Out(Sequence sequence)
        {
            Reset();
        }
        public override void Reset()
        {
            _target.alpha = _alpha1;
        }
    }
}