using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class ColorMultiplyAnimation : UIAnimation
    {
        [SerializeField] private float multiplier = 0.75f;
        [SerializeField] private Image[] _image;
        
        private List<Color> _originalColors = new List<Color>();
        private bool _hasColor;

        public override void In(Sequence sequence)
        {
            if (!_hasColor)
            {
                for (int i = 0; i < _image.Length; i++)
                {
                    if (_image[i] != null)
                        _originalColors.Add(_image[i].color);
                }

                _hasColor = true;
            }
            
            for (int i = 0; i < _image.Length; i++)
            {
                var modifiedColor = new Color(_image[i].color.r * multiplier, _image[i].color.g * multiplier,
                    _image[i].color.b * multiplier, _image[i].color.a);
                
                sequence.Join(_image[i].DOColor(modifiedColor, _duration).SetEase(_ease));
            }
        }
        public override void Out(Sequence sequence)
        {
            if (!_hasColor)
            {
                for (int i = 0; i < _image.Length; i++)
                {
                    if (_image[i] != null)
                        _originalColors.Add(_image[i].color);
                }

                _hasColor = true;
            }
            
            for (int i = 0; i < _image.Length; i++)
                sequence.Join(_image[i].DOColor(_originalColors[i], _duration).SetEase(_ease));
        }
        public override void Reset()
        {
            if (_originalColors.Count <= 0)
                return;
            
            for (int i = 0; i < _image.Length; i++)
                _image[i].color = _originalColors[i];
        }
    }
}