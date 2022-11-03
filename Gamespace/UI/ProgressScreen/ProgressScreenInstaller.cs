using UnityEngine;
using Zenject;

namespace Gamespace.UI.ProgressScreen
{
    [CreateAssetMenu(menuName = "Progress Screen/Create ProgressScreenInstaller", fileName = "ProgressScreenInstaller", order = 0)]
    public class ProgressScreenInstaller : ScriptableObjectInstaller<ProgressScreenInstaller>
    {
        [SerializeField] private ProgressScreenSettings _settings;
        public override void InstallBindings()
        {
            Container.Bind<ProgressScreenWorker>().AsSingle();
            Container.Bind<ProgressScreenSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<Object, IProgressScreen, IProgressScreen.Factory>().FromFactory<ProgressScreenFactory>();

            Container.DeclareSignal<ProgressScreenRequestSignal>();
            Container.DeclareSignal<ProgressScreenCompleteSignal>();
            
            Container.BindSignal<ProgressScreenRequestSignal>().ToMethod<ProgressScreenWorker>(getter => getter.OnScreenProgressResponse).FromResolve();
            Container.BindSignal<ProgressScreenCompleteSignal>().ToMethod<ProgressScreenWorker>(getter => getter.OnScreenProgressCompleted).FromResolve();
        }
    }
}