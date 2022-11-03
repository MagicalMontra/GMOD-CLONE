using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using Zenject;

namespace Gamespace.UI
{
    public class BlurStackWorker
    {
        public string name => _name;

        private string _name;
        private Tween _tween;
        private ScalableBlurConfig _source;
        private List<float> _stack = new List<float>();

        public void Intialize(ScalableBlurConfig source)
        {
            _source = source;
            _name = _source.name;
        }
        public void Push(float target, float duration, Ease ease)
        {
            if (!_stack.Exists(stack => stack == target))
                _stack.Add(target);

            if (target < _stack.Max())
                target = _stack.Max();
            
            _tween?.Kill();
            _tween = DOTween.To(() => _source.Strength, x => _source.Strength = x, target, duration).SetEase(ease);
            _tween.Play();
        }
        public void Pop(float duration, Ease ease)
        {
            _stack = _stack.OrderByDescending(x => x).ToList();
            float target = 0;

            if (_stack.Count > 0)
            {
                _stack.RemoveAt(_stack.Count - 1);
                
                if (_stack.Count > 0)
                    target = _stack[_stack.Count - 1];
            }
            
            
            _tween?.Kill();
            _tween = DOTween.To(() => _source.Strength, x => _source.Strength = x, target, duration).SetEase(ease);
            _tween.Play();
        }
        
        public class Factory : PlaceholderFactory<ScalableBlurConfig, BlurStackWorker> {}
    }
}