using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class FadeInAnimation : UIAnimation
    {
        [SerializeField] private CanvasGroup[] _highlighters;

        public override void In(Sequence sequence)
        {
            for (int i = 0; i < _highlighters.Length; i++)
                sequence.Join(_highlighters[i].DOFade(1, _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            for (int i = 0; i < _highlighters.Length; i++)
                sequence.Join(_highlighters[i].DOFade(0, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            for (int i = 0; i < _highlighters.Length; i++)
                _highlighters[i].alpha = 0;
        }
    }
}