using System;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class FloorSliderWorker : IInitializable,ILateDisposable
    {
        public float currentFloor => _settings.floorSlider.value;
        private int _currentMax;
        private int _currentMin;
        [Inject] private SignalBus _signalBus;
        [Inject] private FloorSliderSettings _settings;
        [Inject] private FloorSliderInputWorker _floorSliderInputWorker;

        private bool _isPause;
        public void Initialize()
        {
            _currentMax = Mathf.CeilToInt(_settings.roomCapacity * 0.5f);
            _currentMin = -Mathf.CeilToInt(_settings.roomCapacity * 0.5f);
            _settings.floorSlider.maxValue = _currentMax;
            _settings.floorSlider.minValue = _currentMin;
            _settings.floorSlider.value = 0;
            _floorSliderInputWorker.Initialize(OnPressAddFloor);
            _signalBus.Subscribe<PauseRequestSignal>(OnPauseRequestSignal);
        }
        public void LateDispose()
        {
            _floorSliderInputWorker.Dispose();
        }
        public void OnPressAddFloor(float input)
        {
            if(_isPause)
                return;
                
            if (input == 0)
            {
                ReduceFloor();
            }
            else
            {
                AddFloor();
            }

        }
        public void AddFloor()
        {
            _settings.floorSlider.value++;
            _settings.floorText.text = "" + _settings.floorSlider.value;
        }
        public void ReduceFloor()
        {
            _settings.floorSlider.value--;
            _settings.floorText.text = "" + _settings.floorSlider.value;
        }
        public void EnableFloorGameobject(bool isEnable)
        {
            _settings.floorSlider.gameObject.SetActive(isEnable);
        }
        public void OnPauseRequestSignal(PauseRequestSignal signal)
        {
            _isPause = signal.isPause;
        }
    }
}
