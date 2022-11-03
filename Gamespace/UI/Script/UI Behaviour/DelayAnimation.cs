using System;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class DelayAnimation : UIAnimation
    {
        public override void In(Sequence sequence)
        {
            sequence.AppendInterval(_duration);
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendInterval(_duration);
        }
    }
}