using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [Serializable]
    public class PlaceableCategoryIndicatorSettings
    {
        public GameObject categoryImagePrefab;
        public Transform categoryIndicatorTransform;
        public PlaceableObjectCategoryUI categoryUI;
    }
}