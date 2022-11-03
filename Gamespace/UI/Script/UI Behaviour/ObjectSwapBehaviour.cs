using UnityEngine;
using UnityEngine.EventSystems;

namespace Gamespace.UI
{
    public class ObjectSwapBehaviour : MonoBehaviour, IExtendedUI
    {
        public Event onSelected;
        public Event onDeselected;
        internal bool isActive = false;
        [SerializeField] private ExtendedUIAsset _field;

        void OnEnable()
        {
            if (isActive)
            {
                OnReset();
            }
            else
            {
                OnDisable();
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (!isActive)
                return;

            OnPress();
        }
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (!isActive)
                return;
        }
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!isActive)
                return;

            if (!Application.isMobilePlatform)
                OnHighlight();
            else
                OnPress();
        }
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (!isActive)
                return;

            OnReset();
        }
        internal virtual void Update()
        {
            if (isActive)
            {
                OnReset();
            }
            else
            {
                OnDisable();
            }
        }
        public virtual void OnHighlight()
        {
            if (_field.onNormal != null)
                _field.onNormal.SetActive(false);

            if (_field.onPressBg != null)
                _field.onPressBg.SetActive(false);

            if (_field.onHighlightBg != null)
                _field.onHighlightBg.SetActive(true);

            if (_field.onDisableBg != null)
                _field.onDisableBg.SetActive(false);
        }
        public virtual void OnPress()
        {
            if (_field.onNormal != null)
                _field.onNormal.SetActive(false);

            if (_field.onPressBg != null)
                _field.onPressBg.SetActive(true);

            if (_field.onHighlightBg != null)
                _field.onHighlightBg.SetActive(false);

            if (_field.onDisableBg != null)
                _field.onDisableBg.SetActive(false);
        }
        public virtual void OnDisable()
        {
            if (_field.onNormal != null)
                _field.onNormal.SetActive(false);

            if (_field.onPressBg != null)
                _field.onPressBg.SetActive(false);

            if (_field.onHighlightBg != null)
                _field.onHighlightBg.SetActive(false);

            if (_field.onDisableBg != null)
                _field.onDisableBg.SetActive(true);
        }
        public virtual void OnReset()
        {
            if (_field.onNormal != null)
                _field.onNormal.SetActive(true);

            if (_field.onPressBg != null)
                _field.onPressBg.SetActive(false);

            if (_field.onHighlightBg != null)
                _field.onHighlightBg.SetActive(false);

            if (_field.onDisableBg != null)
                _field.onDisableBg.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}