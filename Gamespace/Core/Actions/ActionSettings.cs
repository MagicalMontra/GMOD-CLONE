using System;
using Gamespace.UI;
using LeTai.Asset.TranslucentImage;
using TMPro;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    [Serializable]
    public class ActionSettings
    {
        public Camera camera;
        public GameObject panel;
        public GameObject pageGroup;
        public Transform propertySlot;
        public GameObject linkIndicator;
        public ExtendedButton backButton;
        public Transform sliderPoolTransform;
        public GameObject linkCancelIndicator;
        public ActionLinkRenderer linkRenderer;
        public Transform inputFieldPoolTransform;
        public TextMeshProUGUI actionPropertyTitle;
        public ActionPropertyUIElement sliderUIElementPrefab;
        public ActionPropertyUIElement inputFieldUIElementPrefab;
    }
}