using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionLinkRendererFactory : IFactory<Object, ActionLinkRenderer>
    {
        private DiContainer _container;
        public ActionLinkRendererFactory(DiContainer container)
        {
            _container = container;
        }
        public ActionLinkRenderer Create(Object prefab)
        {
            return _container.InstantiatePrefabForComponent<ActionLinkRenderer>(prefab);
        }
    }
}