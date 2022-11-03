using System;
using Gamespace.Utilis;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlacingData
    {
        public bool isEnabled;
        public Vector3 position;
        public Vector3 normal;
        public Vector3 up;
        
        public void Set(bool isEnabled, Vector3 position)
        {
            this.isEnabled = isEnabled;
            this.position = position;
            normal = Vector3.up;
        }
        public void Set(Vector3 position, Vector3 normal, Vector3 up)
        {
            isEnabled = true;
            this.position = position;
            this.normal = normal;
            this.up = up;
        }
    }
}