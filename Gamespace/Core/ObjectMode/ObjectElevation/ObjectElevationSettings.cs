using System;
using TMPro;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Elevation
{
    [Serializable]
    public class ObjectElevationSettings
    {
        public float elevationLimits = 10f;
        public GameObject indicatorPanel;
        public TextMeshProUGUI indicatorText;
    }
}