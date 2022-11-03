using UnityEngine;
using Zenject;

namespace Gamespace.AtmosphereSettings
{
    public class AtmosphereInstaller : MonoInstaller<AtmosphereInstaller>
    {
        [SerializeField] private AtmosphereSetting _atmosphereSetting;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AtmosphereWorker>().AsSingle();
            Container.Bind<AtmosphereSetting>().FromInstance(_atmosphereSetting).AsSingle();
        }
    }
}
