using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class LoadingScreenFactory : IFactory<Object, LoadingScreen>
    {
        private DiContainer _container;

        public LoadingScreenFactory(DiContainer container)
        {
            _container = container;
        }
        public LoadingScreen Create(Object language)
        {
            return _container.InstantiatePrefabForComponent<LoadingScreen>(language);
        }
    }
}