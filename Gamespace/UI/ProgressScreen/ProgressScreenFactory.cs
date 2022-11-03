using UnityEngine;
using Zenject;

namespace Gamespace.UI.ProgressScreen
{
    public class ProgressScreenFactory : IFactory<Object, IProgressScreen>
    {
        private DiContainer _container;
        public ProgressScreenFactory(DiContainer container)
        {
            _container = container;
        }
        public IProgressScreen Create(Object prefab)
        {
            return _container.InstantiatePrefabForComponent<IProgressScreen>(prefab);
        }
    }
}