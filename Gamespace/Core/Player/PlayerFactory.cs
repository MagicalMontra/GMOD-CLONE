using nanoid;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayerFactory : IFactory<Object, Vector3, PlayModePlayer>
    {
        private DiContainer _container;
        
        public PlayerFactory(DiContainer container)
        {
            _container = container;
        }
        public PlayModePlayer Create(Object prefab, Vector3 position)
        {
            var instance = _container.InstantiatePrefabForComponent<PlayModePlayer>(prefab);
            instance.playerPosition = position;
            instance.id = NanoId.Generate(8);
            return instance;
        }
    }
}