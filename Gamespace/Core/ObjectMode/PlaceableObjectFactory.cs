using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode
{
    public class PlaceableObjectFactory : IFactory<Object, IPlaceableObject>
    {
        private DiContainer _container;

        public PlaceableObjectFactory(DiContainer container)
        {
            _container = container;
        }
        public IPlaceableObject Create(Object prefab)
        {
            return _container.InstantiatePrefabForComponent<IPlaceableObject>(prefab);
        }
    }
}