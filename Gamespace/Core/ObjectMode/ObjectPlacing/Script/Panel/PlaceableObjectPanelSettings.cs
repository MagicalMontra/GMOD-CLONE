using System;
using TMPro;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlaceableObjectPanelSettings
    {
        public Transform buttonSlot;
        public GameObject panel;
        public PlaceableObjectUIButton button;
    }

    [Serializable]
    public class PlaceableObjectNameIndicatorSettings
    {
        public TextMeshProUGUI text;
        public GameObject gameObject;
        public CanvasGroup fader;
        public RectTransform rectTransform;
    }
}