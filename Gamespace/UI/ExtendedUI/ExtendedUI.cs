using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gamespace.UI
{
    public abstract class ExtendedUI : MonoBehaviour, IExtendedUI
    {
        public bool isInteractable
        {
            get => _isInteractable;
            set => _isInteractable = value;
        }
        
        [SerializeField] protected UIAnimationFacade _clickBehaviour;
        [SerializeField] protected UIAnimationFacade _hoverBehaviour;
        [SerializeField] protected UIAnimationFacade _disableBehaviour;

        public UnityEvent onHover;
        
        protected bool _isActive = true;
        protected bool _isPointerDown;
        
        private bool _isInteractable = true;
        private bool _isPastEnabled;

        protected virtual void Awake()
        {

        }
        protected virtual void OnEnable()
        {
            _hoverBehaviour?.Behaviour?.Reset();
            _isPastEnabled = true;
        }
        protected virtual void FixedUpdate()
        {
            if (!_isPastEnabled)
                return;
            
            if (_isActive != _isInteractable)
            {
                _isActive = _isInteractable;

                if (!_isActive)
                    _disableBehaviour?.Behaviour?.On().Forget();
                else
                    _disableBehaviour?.Behaviour?.Off().Forget();
            }
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (!_isActive || eventData.button != PointerEventData.InputButton.Left)
                return;
            
            if (Application.isMobilePlatform)
                _hoverBehaviour?.Behaviour?.On().Forget();
            
            _clickBehaviour?.Behaviour?.On().Forget();
            _isPointerDown = true;
        }
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!_isActive || Application.isMobilePlatform)
                return;

            Hover();
            _hoverBehaviour?.Behaviour?.On().Forget();
        }
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (!_isActive || Application.isMobilePlatform)
                return;
            
            _hoverBehaviour?.Behaviour?.Off().Forget();
        }
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (!_isActive || !_isPointerDown)
                return;
            
            if (Application.isMobilePlatform)
                _hoverBehaviour?.Behaviour?.Off().Forget();
            
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _isPointerDown = false;
            _clickBehaviour?.Behaviour?.Off().Forget();
        }
        protected virtual void Hover()
        {
            onHover?.Invoke();
        }
    }
}