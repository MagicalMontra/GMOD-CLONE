using System.Text.RegularExpressions;
using DG.Tweening;
using Gamespace.Localization;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableCategoryNameIndicator : ITickable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private TranslatorFacade _translator;
        [Inject] private PlaceableObjectNameIndicatorSettings _settings;

        private Tween _tween;
        private RectTransform _rect;
        private bool _neededUpdate;
        
        public void OnPlaceableHoverRequest(PlaceableObjectHoverRequestSignal signal)
        {
            _settings.fader.alpha = 0;
            _translator.Translate("Object", signal.name, (value) =>
            {
                _settings.gameObject.SetActive(true);
                _rect = signal.rect;
                _tween?.Kill();
                _tween = _settings.fader.DOFade(1, 0.25f).SetEase(Ease.InOutCirc);
                _tween.Play();
                _settings.text.text = value;
                _neededUpdate = true;
                _signalBus.Fire(new WordWrapRequestSignal(value, _settings.text));
            });
        }
        public void OnObjectPanelPageChanged(ICategoryPanelChangeSignal signal)
        {
            _tween?.Kill();
            _tween = _settings.fader.DOFade(0, 0.25f).SetEase(Ease.InOutCirc).OnComplete(() => _settings.gameObject.SetActive(false));
            _tween.Play();
            _rect = null;
            _neededUpdate = false;
        }
        public void OnPlaceableHoverCancel(PlaceableObjectHoverCancelSignal signal)
        {
            _tween?.Kill();
            _rect = null;
            _neededUpdate = false;
            _settings.gameObject.SetActive(false);
        }

        public void Tick()
        {
            if (_rect is null)
                return;
            
            if (!_neededUpdate)
                return;

            _settings.rectTransform.position = _rect.position;
        }
    }
}