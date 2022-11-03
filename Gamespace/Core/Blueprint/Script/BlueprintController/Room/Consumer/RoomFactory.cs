using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Blueprint
{
    public class RoomFactory : IFactory<UnityEngine.Object, RoomConsumer>
    {
        [Inject] RoomBuildPanelSetting _roomBuildPanelSetting;
         readonly DiContainer _container;

        public RoomFactory(DiContainer container)
        {
            _container = container;
        }
        public RoomConsumer Create(UnityEngine.Object prefab)
        {
            return _container.InstantiatePrefabForComponent<RoomConsumer>(prefab);
        }
    }
}
