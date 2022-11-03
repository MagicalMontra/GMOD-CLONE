using System;
using System.Collections.Generic;
using DG.Tweening;
using Gamespace.Utilis;
using UnityEngine;

namespace Gamespace.UI
{
    public enum CompositeMode
    {
        Join = 0,
        Sequence
    };
    [Serializable]
    public class CompositeAnimation : UIAnimation
    {
        [SerializeField] private bool _reverseOut;
        [SerializeField] private CompositeMode _mode;
        
        public override float Duration {
            get
            {
                var duration = 0f;

                for (int i = 0; i < _behaviours.Count; i++)
                {
                    if (_mode == 0)
                    {
                        if (_behaviours[i].Function.Duration > duration)
                            duration = _behaviours[i].Function.Duration;
                    }
                    else
                    {
                        duration += _behaviours[i].Function.Duration;
                    }
                }
                

                return duration + _duration;
            }
        }
        
        [TypeConstraint(typeof(IUIAnimation))]
        [SerializeField]
        private List<UIAnimationFacade> _behaviours = new List<UIAnimationFacade>();

        public override void In(Sequence sequence)
        {
            for (int i = 0; i < _behaviours.Count; i++)
            {
                if (_mode == 0)
                {
                    var behaviour = _behaviours[i];
                    sequence.AppendCallback(() => behaviour.Behaviour?.On().Forget());
                }
                else
                {
                    var behaviour = _behaviours[i];
                    sequence.AppendCallback(() => behaviour.Behaviour?.On().Forget());
                    sequence.AppendInterval(behaviour.Behaviour.Duration);
                }
                
            }
        }

        public override void Out(Sequence sequence)
        {
            if (_reverseOut)
            {
                for (int i = _behaviours.Count - 1; i >= 0; i--)
                {
                    if (_mode == 0)
                    {
                        var behaviour = _behaviours[i];
                        sequence.AppendCallback(() => behaviour.Behaviour?.Off().Forget());
                    }
                    else
                    {
                        var behaviour = _behaviours[i];
                        sequence.AppendCallback(() => behaviour.Behaviour?.Off().Forget());
                        sequence.AppendInterval(behaviour.Behaviour.Duration);
                    }
                
                }
                
                return;
            }
            
            for (int i = 0; i < _behaviours.Count; i++)
            {
                if (_mode == 0)
                {
                    var behaviour = _behaviours[i];
                    sequence.AppendCallback(() => behaviour.Behaviour?.Off().Forget());
                }
                else
                {
                    var behaviour = _behaviours[i];
                    sequence.AppendCallback(() => behaviour.Behaviour?.Off().Forget());
                    sequence.AppendInterval(behaviour.Behaviour.Duration);
                }
                
            }
        }
        public override void Reset()
        {
            for (int i = 0; i < _behaviours.Count; i++)
                _behaviours[i]?.Behaviour?.Reset();
        }
    }
}