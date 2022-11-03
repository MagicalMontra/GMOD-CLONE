using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.GameStage
{
    [CreateAssetMenu(menuName = "GameMode/Create GameModeInstaller", fileName = "GameModeInstaller", order = 0)]
    public class GameStageInstaller : ScriptableObjectInstaller<GameStageInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStageController>().AsSingle();
            Container.Bind<GameStageEnableStack>().AsSingle();
            Container.Bind<DarumaOtoshiStack>().AsTransient().WhenInjectedInto<GameStageEnableStack>();
            Container.BindInterfacesAndSelfTo<GameStageSwitchInputWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStageEnterPlayModeInputWorker>().AsSingle();
            Container.Bind<GameStageKeyMap>().AsSingle();

            Container.DeclareSignal<Stage>();
            Container.DeclareSignal<GameStageSignal>();
            Container.DeclareSignal<GetStageSignal>();
            Container.DeclareSignalWithInterfaces<GameStageEnableSignal>();
            Container.DeclareSignalWithInterfaces<GameStageDisableSignal>();

            Container.BindSignal<Stage>().ToMethod<GameStageController>(getter => getter.OnGameStageChanged).FromResolve();
            Container.BindSignal<GetStageSignal>().ToMethod<GameStageController>(getter => getter.GetStage).FromResolve();
            
            Container.BindSignal<IGameStageEnableSignal>().ToMethod<GameStageEnableStack>(getter => getter.OnGameStageEnable).FromResolveAll();
            Container.BindSignal<IGameStageDisableSignal>().ToMethod<GameStageEnableStack>(getter => getter.OnGameStageDisable).FromResolveAll();
        }
    }
}