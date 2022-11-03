using DG.Tweening;
using Zenject;

namespace Gamespace.UI
{
    public class CircleMiddleWorker
    {
        [Inject] private CircleWheelSettings _settings;

        private Tween _tween;
        private string _currentId;

        public void Handle(ExtendedWheelButton segment)
        {
            if (_currentId != segment.id || string.IsNullOrEmpty(_currentId))
            {
                _tween?.Kill();
                _tween = _settings.middleBackground.DOColor(segment.customColor, _settings.lerpAmount);
                _tween.Play();
                
                _settings.middleIcon.sprite = segment.icon;
                _settings.middleNameText.text = segment.id;
                _settings.middleDescText.text = segment.desc;
                _currentId = segment.id;
            }
        }
    }
}