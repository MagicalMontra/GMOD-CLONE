using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlacingRaycastSettings
    {
        public float floatingDistance;
        public float inDirectDistance = 1.5f;
        public LayerMask castingMask;
        public Camera mainCamera;
    }
}