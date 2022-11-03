using System;
using UnityEngine;
using Zenject;

namespace Gamespace.UI.Gauge
{
    public class GaugeTypeSelector
    {
        [Inject] private GaugeTypeSettings _settings;

        public GameObject GetMatchingType(Type type)
        {
            var index = _settings.prefabs.FindIndex(prefab => prefab.GetComponent<IGaugeUI>().GetType() == type);

            if (index > -1)
                return _settings.prefabs[index];

            return null;
        }
    }

}



