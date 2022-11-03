using UnityEngine;
using Zenject;

namespace Gamespace.Core.Music
{
    public class BackgroundMusicInstaller : MonoInstaller<BackgroundMusicInstaller>
    {
        [SerializeField] private BackGroundMusicSetting _backGroundMusicSetting;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BackgroundWorker>().AsSingle();
            Container.Bind<BackGroundMusicSetting>().FromInstance(_backGroundMusicSetting).AsSingle();
        }
    }


}
