using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private UIAnimationFacade _transitAnimation;
        [SerializeField] private UIAnimationFacade _loadingAnimation;

        private bool _isInit;
        
        public void Push()
        {
            if (!_isInit)
            {
                _transitAnimation.Function?.outComplete.AddListener(() =>
                {
                    _loadingAnimation.Behaviour?.Reset();
                    gameObject.SetActive(false);
                });

                _isInit = true;
            }
            
            gameObject.SetActive(true);
            _transitAnimation.Behaviour?.On().Forget();
            _loadingAnimation.Behaviour?.On().Forget();
        }
        public void Pop()
        {
            _transitAnimation.Behaviour?.Off().Forget();
        }
        
        public class Factory : PlaceholderFactory<Object, LoadingScreen> {}
    }
}