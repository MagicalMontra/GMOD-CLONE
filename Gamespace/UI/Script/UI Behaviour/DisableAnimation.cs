using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class DisableAnimation : UIAnimation
    {
        [SerializeField] private Image[] _image;
        [SerializeField] private List<Color> _originalColors = new List<Color>();
        [SerializeField] private bool _resetOnEnabled = true;
        private bool _hasColor;
        
        public override void In(Sequence sequence)
        {
            for (int i = 0; i < _image.Length; i++)
                sequence.Join(_image[i].DOColor(new Color(.75f,.75f,.75f, 1f), _duration).SetEase(_ease));
        }

        public override void Out(Sequence sequence)
        {
            for (int i = 0; i < _image.Length; i++)
            {
                if (i > _originalColors.Count)
                    break;
                
                sequence.Join(_image[i].DOColor(_originalColors[i], _duration).SetEase(_ease));
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            if (!_resetOnEnabled)
                return;
            
            if (!_hasColor)
            {
                for (int i = 0; i < _image.Length; i++)
                {
                    if (!ReferenceEquals(_image[i], null))
                        _originalColors.Add(_image[i].color);
                }

                _hasColor = true;
            }
        }
    }
}