using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class ExtendedSlider : ExtendedUI
    {
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private bool _percentageMode;
        
        private Slider _slider;
        
        protected override void Awake()
        {
            base.Awake();
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.onValueChanged.AddListener((a) => UpdateText());
            UpdateText();
        }

        void UpdateText()
        {
            if (_valueText == null)
                return;

            if (_percentageMode) 
                _valueText.text = (_slider.normalizedValue * 100).ToString("N0") + "%";
            else
                _valueText.text = _slider.normalizedValue.ToString("N1");
        }
    }
}