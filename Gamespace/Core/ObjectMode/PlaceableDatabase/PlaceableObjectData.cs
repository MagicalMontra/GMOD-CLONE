using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlaceableObjectData
    {
        public string name;
        public GameObject prefab;
        public Texture2D icon;

        public PlaceableObjectData(string name, GameObject prefab, Texture2D icon)
        {
            this.name = name;
            this.prefab = prefab;
            this.icon = icon;
        }
    }
}