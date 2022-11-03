using System;
using Gamespace.Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorFacade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private RectTransform _referencePoint;
        [SerializeField] private LocalisedString _localisedString;

        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Show();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Cancel();
        }
        private void OnDisable()
        {
            Cancel();
        }
        private void OnDestroy()
        {
            Cancel();
        }
        public void Show()
        {
            _signalBus.Fire(new HoverIndicatorRequestSignal(_localisedString.key, _localisedString.clusterTag, _referencePoint));
        }
        public void Cancel()
        {
            _signalBus.Fire(new HoverIndicatorCancelSignal(_localisedString.key));
        }
    }
}