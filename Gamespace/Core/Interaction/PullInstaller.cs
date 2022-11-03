using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.Interaction
{
    public class PullInstaller : Installer<PullInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PullableWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<PullableInputWorker>().AsSingle();
            
            Container.BindSignal<GameStageSignal>().ToMethod<PullableWorker>(getter => getter.OnGameStageChanged).FromResolve();
        }
    }
}