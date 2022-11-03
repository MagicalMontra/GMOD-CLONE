using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI.Gauge
{
    public class VerticalGaugeUI : MonoBehaviour, IGaugeUI
    {
        public float value
        {
            get => _slider.value;
            set => _slider.value = value;
        }
        public Type type => typeof(VerticalGaugeUI);
        [SerializeField] private Slider _slider;

        public void Reset()
        {
            _slider.value = 0;
            gameObject.SetActive(true);
        }
        public void Despawn()
        {
            gameObject.SetActive(false);
        }
    }
}