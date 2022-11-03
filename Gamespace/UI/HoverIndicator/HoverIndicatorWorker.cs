using Gamespace.Localization;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorWorker : ITickable
    {
        [Inject] private TranslatorFacade _translator;
        [Inject] private HoverIndicatorSettings _settings;
        [Inject] private IHoverIndicator.Factory _indicatorFactory;

        private string _uniqueId;
        private bool _neededUpdate;
        private RectTransform _rect;
        private IHoverIndicator _indicator;

        public void OnIndicatorRequest(HoverIndicatorRequestSignal signal)
        {
            _indicator ??= _indicatorFactory.Create(_settings.indicatorPrefab, _settings.indicatorSlot);
            _translator.Translate(signal.translateClusterName, signal.name, (value) =>
            {
                _rect = signal.rect;
                _neededUpdate = true;
                _indicator.Enable(value);
            });

            _uniqueId = signal.name;
        }
        public void OnIndicatorCancel(HoverIndicatorCancelSignal signal)
        {
            if (_uniqueId != signal.name)
                return;
            
            _rect = null;
            _neededUpdate = false;
            _indicator.Disable();
            _uniqueId = "";
        }
        public void Tick()
        {
            if (_indicator is null)
                return;
            
            if (_rect is null)
                return;

            if (!_neededUpdate)
                return;

            _indicator.UpdatePosition(_rect.position);
        }
    }
}
