using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Gamespace.Core.Blueprint
{
    [Serializable]
    public class FloorSliderSettings
    {
        public int roomCapacity = 10;
        public TextMeshProUGUI floorText;
        public Slider floorSlider;
    }
}
