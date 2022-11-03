using UnityEngine;
using Zenject;

namespace Gamespace.UI.Gauge
{
    public class GameObjectGaugeUIFactory : IFactory<GameObject, Transform, IGaugeUI>
    {
        private DiContainer _container;
        public GameObjectGaugeUIFactory(DiContainer container)
        {
            _container = container;
        }
        public IGaugeUI Create(GameObject prefab, Transform canvas)
        {
            return _container.InstantiatePrefabForComponent<IGaugeUI>(prefab, canvas);
        }
    }
}
