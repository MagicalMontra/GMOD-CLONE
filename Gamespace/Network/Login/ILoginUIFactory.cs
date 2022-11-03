using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class ILoginUIFactory : IFactory<Object, ILoginUI>
    {
        private DiContainer _container;
        
        public ILoginUIFactory(DiContainer container)
        {
            _container = container;
        }
        public ILoginUI Create(Object language)
        {
            return _container.InstantiatePrefabForComponent<ILoginUI>(language);
        }
    }
}