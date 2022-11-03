using UnityEngine;
using Zenject;

namespace Gamespace.Network.Register
{
    public class IRegisterUIFactory : IFactory<Object, IRegisterUI>
    {
        private DiContainer _container;
        
        public IRegisterUIFactory(DiContainer container)
        {
            _container = container;
        }
        public IRegisterUI Create(Object language)
        {
            return _container.InstantiatePrefabForComponent<IRegisterUI>(language);
        }
    }
}