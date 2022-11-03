using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Gamespace.AtmosphereSettings
{
    public class AtmosphereWorker :IInitializable
    {
         [Inject] private AtmosphereSetting _atmosphereSetting;

         public void Initialize()
        {
                          _atmosphereSetting.weatherDropDown.onValueChanged.AddListener(delegate {
            OnWeatherProfileChange();
        });
                        _atmosphereSetting.weatherSlider.onValueChanged.AddListener(delegate {
            OnDayTimeChange();
        });
                        _atmosphereSetting.postEffectDropDown.onValueChanged.AddListener(delegate {
            OnPostEffectProfileChange();
        });
                        _atmosphereSetting.postEffectSlider.onValueChanged.AddListener(delegate {
            OnPostEffectValueChange();
        });
        
        }

        public void OnWeatherProfileChange()
        {
           _atmosphereSetting.azureWeatherController.SetNewWeatherProfile(_atmosphereSetting.weatherDropDown.value);
        }
       
        public void OnDayTimeChange()
        {
            float sliderValue = _atmosphereSetting.weatherSlider.value;
            sliderValue = sliderValue *_atmosphereSetting.weatherConstant;
            _atmosphereSetting.azureTimeController.SetTimeline(sliderValue);
        }

        public void OnPostEffectProfileChange()
        {
            int profileIndex = _atmosphereSetting.postEffectDropDown.value;
            _atmosphereSetting.globalVolume.Volume.profile = _atmosphereSetting.volumeProfile[profileIndex];
        }
         public void OnPostEffectValueChange()
        {
            _atmosphereSetting.globalVolume.Volume.weight = _atmosphereSetting.postEffectSlider.value;
        }
        public void EnableAtmosphereCanvas(bool isEnable)
        {
            _atmosphereSetting.atmosphereCanvas.gameObject.SetActive(isEnable);
        }

    }

}
