using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class AutoLoginPromptUIFactory : IFactory<Object, AutoLoginPromptUI>
    {
        private DiContainer _container;
        public AutoLoginPromptUIFactory(DiContainer container)
        {
            _container = container;
        }
        public AutoLoginPromptUI Create(Object language)
        {
            return _container.InstantiatePrefabForComponent<AutoLoginPromptUI>(language);
        }
    }
}