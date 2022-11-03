using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelCloseDotweenAnimationWorker : ICircleWheelCloseAnimationWorker
    {
        public bool isClosed => _isClosed;
        
        [Inject] private CircleWheelSettings _settings;

        private bool _isClosed;
        private Sequence _sequence;
        
        public void Initialize(Action closeAction)
        {
            _isClosed = false;
            var targetVector = _settings.closeAnimation == AnimationType.zoomIn ? Vector3.zero : Vector3.one * 10;
            _sequence = DOTween.Sequence();
            _sequence.Append(_settings.panel.transform.DOScale(targetVector, _settings.lerpAmount));
            _sequence.AppendCallback(() =>
            {
                _isClosed = true;
                _settings.panel.SetActive(false);
                closeAction?.Invoke();
            });
            _sequence.Append(_settings.cursor.DOColor(Color.clear, _settings.lerpAmount));
            _sequence.Append(_settings.background.DOColor(Color.clear, _settings.lerpAmount));
        }
        public void Animate()
        {
            _sequence.Play();
        }
        public void Cancel()
        {
            _sequence?.Kill();
        }
    }
}