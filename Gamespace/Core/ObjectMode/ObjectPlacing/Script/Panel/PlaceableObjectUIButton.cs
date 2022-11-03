using System;
using DG.Tweening;
using Gamespace.Core.ObjectMode.Selection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        
        private string _name;
        private Sequence _sequence;
        private RectTransform _rect;

        public void Setup(PlaceableObjectData data)
        {
            _rect = GetComponent<RectTransform>();
            _name = data.name;
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(Vector3.one * 0.95f, 0.25f));
            _sequence.Append(transform.DOScale(Vector3.one, 0.25f));
            _sequence.AppendCallback(() =>
            {
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("PlaceableObjectPanel"));
                _signalBus.AbstractFire(new PlaceableSelectSignal("", "SelectObject", data));
            });
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _sequence.Play());
            _image.sprite = Sprite.Create(data.icon, new Rect(0,0, data.icon.width, data.icon.height), Vector2.one * 0.5f, 100f);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            _signalBus.Fire(new PlaceableObjectHoverRequestSignal(_name, _rect));
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            _signalBus.Fire(new PlaceableObjectHoverCancelSignal());
        }

        public class Factory : PlaceholderFactory<PlaceableObjectUIButton, Transform, PlaceableObjectUIButton>
        {
            
        }
    }
}