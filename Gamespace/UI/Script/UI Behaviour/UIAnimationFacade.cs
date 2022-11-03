using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gamespace.UI
{
    public class UIAnimationFacade : MonoBehaviour
    {
        public IUIAnimation Behaviour => gameObject.GetComponent<IUIAnimation>();
        public UIAnimation Function => gameObject.GetComponent<UIAnimation>();

        [SerializeField] private bool _playOnAwake;
        [SerializeField] private float _awakeDelay;

        private async void OnEnable()
        {
            if (_playOnAwake)
            {
                await Task.Delay(Mathf.CeilToInt(_awakeDelay * 1000));
                Behaviour?.On().Forget();
            }
        }
    }
}