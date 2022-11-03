using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class LocalScaleAnimation : UIAnimation
    {
        [SerializeField] private Vector2 _start;
        [SerializeField] private Vector2 _finish;
        [SerializeField] private GameObject _target;

        public override void In(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScale(_start, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScale(_finish, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.transform.DOScale(_finish, 0.01f).SetEase(_ease));
            sequence.Append(_target.transform.DOScale(_start, _duration).SetEase(_ease));
        }
    }
}