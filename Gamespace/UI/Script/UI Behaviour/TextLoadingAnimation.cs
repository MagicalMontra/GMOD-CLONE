using System;
using DG.Tweening;
using UnityEngine;
using  TMPro;

namespace Gamespace.UI
{
    public class TextLoadingAnimation : UIAnimation
    {
        [SerializeField] private int _dotCount = 3;
        [SerializeField] private TextMeshProUGUI _target;

        private string _originalText;
        private bool _isInit;
        
        public override void In(Sequence sequence)
        {
            if (!_isInit)
            {
                _originalText = _target.text;
                _isInit = true;
            }

            sequence.AppendCallback(() => _target.text = _originalText);

            for (int i = 0; i < _dotCount; i++)
            {
                sequence.AppendCallback(() => _target.text += ".");
                sequence.AppendInterval(_duration / _dotCount);
            }
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendCallback(Reset);
        }
        public override void Reset()
        {
            _sequence?.Kill();
            _target.text = _originalText;
        }
    }
}