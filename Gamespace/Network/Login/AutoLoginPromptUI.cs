using System;
using Gamespace.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.Network.Login
{
    public class AutoLoginPromptUI : MonoBehaviour
    {
        [SerializeField] private UIAnimationFacade _transitAnimation;
        [SerializeField] private ExtendedButton _confirmButton;
        [SerializeField] private ExtendedButton _cancelButton;

        private bool _isInitialized;

        public void Push(Action confirmAction, Action cancelAction)
        {
            Initialize();
            
            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Pop);
            _cancelButton.onClick.AddListener(() => cancelAction.Invoke());
            
            _confirmButton.onClick.RemoveAllListeners();
            _confirmButton.onClick.AddListener(Pop);
            _confirmButton.onClick.AddListener(() => confirmAction.Invoke());
            
            _transitAnimation?.Behaviour?.On().Forget();
        }
        public void Pop()
        {
            Initialize();
            _transitAnimation?.Behaviour?.Off().Forget();
        }
        private void Initialize()
        {
            if (_isInitialized)
                return;
            
            _transitAnimation?.Function?.inStart.AddListener(() => gameObject.SetActive(true));
            _transitAnimation?.Function?.outComplete.AddListener(() => gameObject.SetActive(false));

            _isInitialized = true;
        }
        
        public class Factory : PlaceholderFactory<Object, AutoLoginPromptUI>{}
    }
}