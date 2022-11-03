using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.AzureSky;
namespace Gamespace.AtmosphereSettings
{
    [Serializable]
    public class AtmosphereSetting 
    {
        [Header("UI")]
        [SerializeField] public GameObject atmosphereCanvas;
        [SerializeField] public TMP_Dropdown weatherDropDown;
        [SerializeField] public Slider weatherSlider;
        [SerializeField] public float weatherConstant;
        [SerializeField] public TMP_Dropdown postEffectDropDown;
        [SerializeField] public Slider postEffectSlider;
        [Header("GlobalVolume")]
        [SerializeField] public GlobalVolume globalVolume;
        [SerializeField] public VolumeProfile[] volumeProfile;
        [Header("AzureController")]
        [SerializeField] public AzureTimeController azureTimeController;
        [SerializeField] public AzureWeatherController azureWeatherController;
    }

}
