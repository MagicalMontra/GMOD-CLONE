using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    [Serializable]
    public class CircleWheelSettings
    {
        public bool snap;
        public bool rotateButton;
        public bool needHovering;
        public bool tiltTowardMouse;
        public bool useSeparator;
        public float size = 1f;
        public float radius = 120f;
        public float desiredFill;
        public float tiltAmount = 15f;
        public float zRotation = 0f;
        public float lerpAmount = .145f;
        public float pieThickness = 5f;

        public AnimationType openAnimation;
        public AnimationType closeAnimation;
        public GameObject panel;
        public Image cursor;
        public Image background;
        public Transform buttonSlot;
        public Color backgroundColor;
        public Color accentColor;
        public Color disabledColor;
        public Transform separatorSlot;
        public GameObject buttonPrefab;
        public Image middleIcon;
        public Image middleBackground;
        public WheelSegment separatorPrefab;
        public TextMeshProUGUI middleNameText;
        public TextMeshProUGUI middleDescText;
    }

    [Serializable]
    public enum AnimationType
    {
        zoomIn,
        zoomOut
    }
}