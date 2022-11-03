using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    [CreateAssetMenu(menuName = "Installer/Create LoadingScreenInstaller", fileName = "LoadingScreenInstaller", order = 0)]
    public class LoadingScreenInstaller : ScriptableObjectInstaller<LoadingScreenInstaller>
    {
        [SerializeField] private LoadingScreenSettings _settings;
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreenWorker>().AsSingle();
            Container.Bind<LoadingScreenSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<Object, LoadingScreen, LoadingScreen.Factory>().FromFactory<LoadingScreenFactory>();

            Container.DeclareSignal<LoadingScreenCancelSignal>();
            Container.DeclareSignal<LoadingScreenRequestSignal>();
            
            Container.BindSignal<LoadingScreenCancelSignal>().ToMethod<LoadingScreenWorker>(getter => getter.OnLoadingScreenCancelled).FromResolve();
            Container.BindSignal<LoadingScreenRequestSignal>().ToMethod<LoadingScreenWorker>(getter => getter.OnLoadingScreenRequested).FromResolve();
        }
    }
}