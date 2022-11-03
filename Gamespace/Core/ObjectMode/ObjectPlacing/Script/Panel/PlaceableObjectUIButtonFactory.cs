using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectUIButtonFactory : IFactory<PlaceableObjectUIButton, Transform, PlaceableObjectUIButton>
    {
        private DiContainer _container;
        public PlaceableObjectUIButtonFactory(DiContainer container)
        {
            _container = container;
        }
        public PlaceableObjectUIButton Create(PlaceableObjectUIButton prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<PlaceableObjectUIButton>(prefab, parent);
        }
    }
}