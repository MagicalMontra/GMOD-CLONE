using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class ExtendedWheelButtonFactory : IFactory<GameObject, Quaternion, Transform, ExtendedWheelButton>
    {
        private DiContainer _container;
        
        public ExtendedWheelButtonFactory(DiContainer container)
        {
            _container = container;
        }
        public ExtendedWheelButton Create(GameObject prefab, Quaternion rotation, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<ExtendedWheelButton>(prefab, Vector3.zero, rotation, parent);
        }
    }
}