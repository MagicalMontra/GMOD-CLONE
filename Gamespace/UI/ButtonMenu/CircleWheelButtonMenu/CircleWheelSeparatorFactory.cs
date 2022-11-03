using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelSeparatorFactory : IFactory<float, Object, Transform, GameObject>
    {
        private DiContainer _container;
        public CircleWheelSeparatorFactory(DiContainer container)
        {
            _container = container;
        }
        public GameObject Create(float rotation, Object prefab, Transform parent)
        {
            var separator = _container.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, parent);
            separator.transform.localScale = Vector3.one;
            separator.transform.localPosition = Vector3.zero;
            separator.transform.localRotation = Quaternion.Euler(0, 0, rotation);
            return separator;
        }
    }
}