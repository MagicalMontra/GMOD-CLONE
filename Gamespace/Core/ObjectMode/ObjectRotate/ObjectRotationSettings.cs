using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Rotation
{
    [Serializable]
    public class ObjectRotationSettings
    {
        public GameObject indicator;
        public TextMeshProUGUI axisText;
        public TextMeshProUGUI indicatorText;
    }
}