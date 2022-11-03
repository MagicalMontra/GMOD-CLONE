using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlaceableObjectCategory : ScriptableObject
    {
        public int count => _datas.Count;
        
        public string catName;
        [SerializeField] private List<PlaceableObjectData> _datas = new List<PlaceableObjectData>();

        public bool IsExist(string prefabName)
        {
            return _datas.Exists(data => data.name == prefabName);
        }
        public void Add(GameObject prefab, Texture2D texture2D)
        {
            var newData = new PlaceableObjectData(prefab.name, prefab, texture2D);
            _datas.Add(newData);
        }
        public void Remove(int index)
        {
            _datas.RemoveAt(index);
        }
        public PlaceableObjectData GetObject(int index)
        {
            return _datas[index];
        }
    }
}