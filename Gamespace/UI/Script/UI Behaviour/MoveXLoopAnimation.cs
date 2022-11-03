using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class MoveXLoopAnimation : UIAnimation
    {
        [SerializeField] private float _start = 1f;
        [SerializeField] private float _end = 1f;
        [SerializeField] private bool _autoPlay = false;
        [SerializeField] private Transform _target;

        void Start()
        {
            if (_autoPlay)
                On().Forget();
        }
        public override void In(Sequence sequence)
        {
            sequence.Append(_target.DOLocalMoveX(_end, _duration / 2));
            sequence.Append(_target.DOLocalMoveX(_start, _duration / 2));
            sequence.SetEase(_ease);
        }

        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.DOLocalMoveX(_end, _duration / 2));
            sequence.Append(_target.DOLocalMoveX(_start, _duration / 2));
            sequence.SetEase(_ease);
        }

        public override void Reset()
        {
            var targetPos = _target.localPosition;
            _target.localPosition = new Vector3(_start, targetPos.y, targetPos.z);
        }
    }
}