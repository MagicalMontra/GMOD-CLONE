using UnityEngine;
using Zenject;

namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorFactory : IFactory<Object, Transform, IHoverIndicator>
    {
        private DiContainer _container;
        
        public HoverIndicatorFactory(DiContainer container)
        {
            _container = container;
        }
        public IHoverIndicator Create(Object prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<IHoverIndicator>(prefab, parent);
        }
    }
}