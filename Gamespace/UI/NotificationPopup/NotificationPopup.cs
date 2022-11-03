using System;
using TMPro;
using UnityEngine;
using Gamespace.Localization;
using Gamespace.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.UI
{

    public class NotificationPopup : MonoBehaviour
    {
        [SerializeField] private UIAnimationFacade _popupAnimation;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _context;
        [SerializeField] private TextMeshProUGUI _closeBtnText;
        [SerializeField] private ExtendedButton _closeBtn;

        [Inject] private SignalBus _signalBus;

        private bool _isInit;
        
        public void Push(string title, string context, string buttonContext = "", Action closeAction = null)
        {
            if (!_isInit)
            {
                _popupAnimation.Function.outComplete.AddListener(() => closeAction?.Invoke());
                _isInit = true;
            }
            
            _title.text = title;
            _context.text = context;
            
            _signalBus.Fire(new WordWrapRequestSignal(title, _title));
            _signalBus.Fire(new WordWrapRequestSignal(context, _context));

            if (buttonContext != string.Empty)
            {
                _closeBtnText.text = buttonContext;
                _signalBus.Fire(new WordWrapRequestSignal(buttonContext, _closeBtnText));
            }
            else
                _closeBtnText.text = "Dismiss";

            _closeBtn.onClick.AddListener(Pop);
            gameObject.SetActive(true);
            _popupAnimation.Behaviour?.On().Forget();
        }
        public void Pop()
        {
            _closeBtn.onClick.RemoveAllListeners();
            _popupAnimation.Behaviour?.Off().Forget();
        }
        
        private void Reset()
        {
            _closeBtn.onClick.RemoveAllListeners();
            _popupAnimation.Behaviour?.Reset();
            _popupAnimation.Function.outComplete.RemoveAllListeners();
            _isInit = false;
        }
        
        public class Pool : MonoMemoryPool<NotificationPopup>
        {
            protected override void Reinitialize(NotificationPopup popup)
            {
                popup.Reset();
            }
        }
    }
}