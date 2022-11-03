using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlacableObjectCategoryIndicatorFactory : IFactory<Object, Transform, PlaceableCategoryUIButton>
    {
        private DiContainer _container;

        public PlacableObjectCategoryIndicatorFactory(DiContainer container)
        {
            _container = container;
        }
        public PlaceableCategoryUIButton Create(Object prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<PlaceableCategoryUIButton>(prefab, parent);
        }
    }
}