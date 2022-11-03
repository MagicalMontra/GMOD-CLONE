using UnityEngine;
using Zenject;
namespace Gamespace.Core.Save
{
    public class SaveLoadInstaller : MonoInstaller<SaveLoadInstaller>
    {
        [SerializeField] private FilePathSetting _filePathSetting;
        [SerializeField] private SaveSetting _saveSetting;
        [SerializeField] private LoadSetting _loadSetting;
        public override void InstallBindings()
        {
             Container.Bind<FilePathSetting>().FromInstance(_filePathSetting).AsSingle();

             Container.Bind<SaveControls>().AsSingle();
             Container.BindInterfacesAndSelfTo<SaveWorker>().AsSingle();
             Container.Bind<SaveInputWorker>().AsSingle();
             Container.Bind<SaveSetting>().FromInstance(_saveSetting).AsSingle();

             Container.BindInterfacesAndSelfTo<LoadWorker>().AsSingle();
             Container.Bind<LoadSetting>().FromInstance(_loadSetting).AsSingle();

             Container.DeclareSignal<PauseRequestSignal>();
             Container.DeclareSignal<SaveRequestSignal>();
        }
    }

}
