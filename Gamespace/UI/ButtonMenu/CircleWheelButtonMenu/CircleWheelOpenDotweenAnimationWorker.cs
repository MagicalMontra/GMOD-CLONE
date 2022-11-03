using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelOpenDotweenAnimationWorker : ICircleWheelOpenAnimationWorker
    {
        public bool isOpened => _isOpened;
        
        [Inject] private CircleWheelSettings _settings;

        private bool _isOpened;
        private Sequence _sequence;
        
        public void Initialize()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(_settings.panel.transform.DOScale(new Vector3(_settings.size, _settings.size, _settings.size), 0.2f));
            _sequence.OnUpdate(() =>
            {
                if (!_settings.panel.activeInHierarchy)
                    _settings.panel.SetActive(true);
            });
            _sequence.AppendCallback(() => _isOpened = true);
        }
        public void Animate()
        {
            _settings.panel.SetActive(true);
            _isOpened = false;
            _sequence.Play();
        }
    }
}