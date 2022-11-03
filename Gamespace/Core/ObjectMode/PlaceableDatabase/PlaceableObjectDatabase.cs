using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    [CreateAssetMenu(menuName = "Create PlaceableObjectDatabase", fileName = "PlaceableObjectDatabase", order = 0)]
    public class PlaceableObjectDatabase : ScriptableObject
    {
        public int count => _categories.Count;
        [SerializeField] private List<PlaceableObjectCategory> _categories = new List<PlaceableObjectCategory>();

        public void Add(PlaceableObjectCategory catergory)
        {
            _categories.Add(catergory);
        }
        public void Remove(int index)
        {
            _categories.RemoveAt(index);
        }
        public void Clear()
        {
            _categories.Clear();
        }
        public PlaceableObjectCategory GetCategory(int index)
        {
            return _categories[index];
        }
        public PlaceableObjectCategory GetCategory(string name)
        {
            var category = _categories.Find(cat => cat.catName == name);
            return category;
        }
        public int GetIndex(string name)
        {
            var index = _categories.FindIndex(cat => cat.catName == name);

            if (index < 0)
                index = 0;
            
            return index;
        }
    }
}