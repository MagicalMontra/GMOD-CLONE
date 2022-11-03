using System.Threading.Tasks;
using Gamespace.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.UI
{
    public class ExtendedDropElement : ExtendedButton
    {
        public ExtendedDropData data => _data;

        [SerializeField] private UIAnimationFacade _onExpandAnimation;
        
        [SerializeField] private ExtendedDropData _data;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _checkMark;
        [SerializeField] private TextMeshProUGUI _value;

        [SerializeField] private bool _dyeIcon;
        [SerializeField] private bool _dyeText;

        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<TranslateResponseSignal>(OnTranslated);
        }
        public void Initialize(ExtendedDropData data, Color accentColor)
        {
            _data = data;
            _icon.sprite = _data.icon;
            _checkMark.color = new Color(_checkMark.color.r, _checkMark.color.g, _checkMark.color.b, 0);

            if (_dyeIcon)
                _icon.color = accentColor;

            if (_dyeText)
                _value.color = accentColor;
                    
            _checkMark.GetComponent<Image>().color = accentColor;
            GetComponent<CanvasGroup>().alpha = 0;
        }
        public void SetMark(bool enabled)
        {
            if (enabled)
                _checkMark.color = new Color(_checkMark.color.r, _checkMark.color.g, _checkMark.color.b, 1f);
            else
                _checkMark.color = new Color(_checkMark.color.r, _checkMark.color.g, _checkMark.color.b, 0);
        }
        public void OnExpand(bool enabled)
        {
            if (enabled)
            {
                _onExpandAnimation?.Behaviour?.On().Forget();
                _signalBus?.Fire(new TranslateRequestSignal(_data.clusterTag, _data.value));
            }
            else
                _onExpandAnimation?.Behaviour?.Off().Forget();
        }

        protected override void Hover()
        {
            
        }
        private void OnTranslated(TranslateResponseSignal signal)
        {
            if (_data.value != signal.key)
                return;

            if (ReferenceEquals(_value, null))
                return;
            
            _value.text = signal.value;
            _signalBus.Fire(new WordWrapRequestSignal(signal.value, _value));
        }
    }
}