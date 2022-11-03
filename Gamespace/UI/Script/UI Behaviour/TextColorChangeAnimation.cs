using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class TextColorChangeAnimation : UIAnimation
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private TextMeshProUGUI[] _texts;
        
        private List<Color> _originalColors = new List<Color>();
        private bool _hasColor;

        public override void Reset()
        {
            if (_originalColors.Count <= 0)
                return;

            for (int i = 0; i < _texts.Length; i++)
                _texts[i].color = _originalColors[i];
        }
        public override void In(Sequence sequence)
        {
            if (!_hasColor)
            {
                for (int i = 0; i < _texts.Length; i++)
                    _originalColors.Add(_texts[i].color);

                _hasColor = true;
            }
            
            for (int i = 0; i < _texts.Length; i++)
                sequence.Join(_texts[i].DOColor(new Color(targetColor.r, targetColor.g, targetColor.b, _texts[i].color.a), _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            if (_originalColors.Count <= 0)
                return;

            for (int i = 0; i < _texts.Length; i++)
                sequence.Join(_texts[i].DOColor(new Color(_originalColors[i].r, _originalColors[i].g, _originalColors[i].b, _texts[i].color.a), _duration).SetEase(_ease));
        }
    }
}