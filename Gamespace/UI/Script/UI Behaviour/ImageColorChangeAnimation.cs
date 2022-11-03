using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.UI
{
    public class ImageColorChangeAnimation : UIAnimation
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private Image[] _images;
        [SerializeField] private bool _resetOnEnabled = true;
        
        private List<Color> _originalColors = new List<Color>();
        private bool _hasColor;
        
        public override void In(Sequence sequence)
        {
            for (int i = 0; i < _images.Length; i++)
                sequence.Join(_images[i].DOColor(new Color(targetColor.r, targetColor.g, targetColor.b, _images[i].color.a), _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            for (int i = 0; i < _originalColors.Count; i++)
                sequence.Join(_images[i].DOColor(_originalColors[i], _duration).SetEase(_ease));
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            if (!_hasColor)
            {
                for (int i = 0; i < _images.Length; i++)
                    _originalColors.Add(_images[i].color);

                _hasColor = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            
            if (!Application.isPlaying)
                return;
            
            if (!_resetOnEnabled)
                return;
            
            if (_hasColor)
            {
                for (int i = 0; i < _images.Length; i++)
                {
                    _images[i].color = _originalColors[i];
                }
            }
        }
    }
}