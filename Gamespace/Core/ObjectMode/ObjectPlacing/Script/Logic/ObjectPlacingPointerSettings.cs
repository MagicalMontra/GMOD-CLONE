using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class ObjectPlacingPointerSettings
    {
        public GameObject placingPointer;
        public GameObject disablePointer;
    }

    [Serializable]
    public class ObjectPlacingHintSettings
    {
        public GameObject controlHintPanel;
    }
}