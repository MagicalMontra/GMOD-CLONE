using UnityEngine;
using Zenject;
using UnityEngine.Serialization;
using UnityEngine.AzureSky;
namespace Gamespace.AtmosphereSettings
{
    public class CanvasAtmosphereSettings : MonoBehaviour
    {
      public AzureTimeController azureTimeController;
      public AzureWeatherController azureWeatherController;
      public int azureWeatherIndex;
      
    [Range(-8.0f, 8.0f)] public float floatRange;
        private void Start()
        {
            
        }

        private void Update()
        {
            azureTimeController.SetTimeline(floatRange);
        }
        private void ChangeWeather()
        {
            azureWeatherController.SetNewWeatherProfile(azureWeatherIndex);
        }
    }

}