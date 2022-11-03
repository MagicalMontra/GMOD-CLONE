using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class ImageFillAnimation : UIAnimation
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image.FillMethod _fillMethod;
        [SerializeField] private Image.OriginHorizontal _fillOrigin;
        
        public override void In(Sequence sequence)
        {
            if (_image.type != Image.Type.Filled)
            {
                _image.type = Image.Type.Filled;
                
                if (_image.fillMethod == _fillMethod)
                    _image.fillMethod = _fillMethod;
                
                if (_image.fillOrigin == (int)_fillOrigin)
                    _image.fillOrigin = (int)_fillOrigin;
                
                _image.fillAmount = 0;
            }
            
            sequence.Append(DOTween.To(x => _image.fillAmount = x, _image.fillAmount, 1, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            sequence.Append(DOTween.To(x => _image.fillAmount = x, _image.fillAmount, 0, _duration).SetEase(_ease));
        }

        public override void Reset()
        {
            _image.fillAmount = 0;
        }
    }
}