using System;
using Gamespace.Localization;
using TMPro;
using UnityEngine;

namespace Gamespace.UI
{
    public class PropmtPopup : ExtendedUI
    {
        [SerializeField] private UIAnimationFacade _popupAnimation;

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _context;
        [SerializeField] private TextMeshProUGUI _closeBtnText;
        [SerializeField] private TextMeshProUGUI _acceptBtnText;
        [SerializeField] private ExtendedButton _acceptBtn;
        [SerializeField] private ExtendedButton _closeBtn;

        private bool _isInit;
        
        private void Start()
        {
            // _canvasGroup.interactable = isInteractable;
            // _canvasGroup.blocksRaycasts = isInteractable;
        }
        public void Push(string title, string context, string acceptContext, Action acceptAction, string dismissContext = "", Action dismissAction = null)
        {
            if (!_isInit)
            {
                _popupAnimation.Function.outComplete.AddListener(() => gameObject.SetActive(false));
                _isInit = true;
            }

            _title.text = title;
            _context.text = context;

            if (acceptContext != string.Empty)
                _acceptBtnText.text = acceptContext;
            else
                _acceptBtnText.text = "Okay";
            
            if (dismissContext != string.Empty)
                _closeBtnText.text = dismissContext;
            else
                _closeBtnText.text = "Dismiss";

            _closeBtn.onClick.AddListener(() => Pop(dismissAction));
            _acceptBtn.onClick.AddListener(() => Pop(acceptAction));
            gameObject.SetActive(true);
            _popupAnimation.Behaviour?.On().Forget();
        }
        public void Pop(Action closeAction = null)
        {
            closeAction?.Invoke();
            _acceptBtn.onClick.RemoveAllListeners();
            _closeBtn.onClick.RemoveAllListeners();
            _popupAnimation.Behaviour?.Off().Forget();
        }
    }
}