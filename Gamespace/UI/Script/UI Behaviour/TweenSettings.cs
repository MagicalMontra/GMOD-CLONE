using System;
using DG.Tweening;

namespace Gamespace.UI
{
    [Serializable]
    public class TweenSettings
    {
        public Ease ease = Ease.Linear;
        public float duration = 1f;
    }
}