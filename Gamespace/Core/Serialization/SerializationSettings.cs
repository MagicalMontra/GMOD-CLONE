using System;
using UnityEngine;

namespace Gamespace.Core.Serialization
{
    [Serializable]
    [CreateAssetMenu(menuName = "Serializable/Create SerializationSettings", fileName = "SerializationSettings",
        order = 0)]
    public class SerializationSettings : ScriptableObject
    {
        public string fileName;
        public readonly string filePath = "Data";
        public SerializationMap map;
    }
}