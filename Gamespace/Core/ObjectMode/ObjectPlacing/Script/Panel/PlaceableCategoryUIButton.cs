using Gamespace.UI;
using Zenject;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableCategoryUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image => _image;
        
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Image _image;
        [SerializeField] private ExtendedButton _button;

        private RectTransform _rect;
        private PlaceableObjectCategory _category;

        public void Setup(PlaceableObjectCategory category)
        {
            _category = category;
            _rect = GetComponent<RectTransform>();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _signalBus.AbstractFire(new CategoryPageChangeSignal(_category)));
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            _signalBus?.Fire(new PlaceableObjectHoverRequestSignal($"Category: {_category.catName}", _rect));
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            _signalBus?.Fire(new PlaceableObjectHoverCancelSignal());
        }
        public class Factory : PlaceholderFactory<Object, Transform, PlaceableCategoryUIButton>{}
    }
}