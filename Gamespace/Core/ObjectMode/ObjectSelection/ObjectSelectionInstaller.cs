using Gamespace.Core.GameStage;
using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionInstaller : MonoInstaller<ObjectSelectionInstaller>
    {
        [SerializeField] private ObjectSelectionSettings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObjectSelectionWorker>().AsSingle();
            Container.Bind<ObjectSelectionEnableStack>().AsSingle();
            Container.Bind<DarumaOtoshiStack>().AsTransient().WhenInjectedInto<ObjectSelectionEnableStack>();
            Container.Bind<IObjectSelectionWorker>().To<ObjectSelectionDotsProductWorker>().AsSingle();
            Container.Bind<IObjectSelectionRaycastWorker>().To<ObjectSelectionViewportPointToRayWorker>().AsSingle();
            Container.Bind<ILookSelectionWorker>().To<DotsLookSelectionWorkerCalculator>().WhenInjectedInto<ObjectSelectionDotsProductWorker>();
            Container.Bind<ObjectSelectionOpenPanelInputWorker>().AsSingle();
            Container.Bind<ObjectSelectionSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<ObjectSelectionControls>().AsSingle();

            Container.DeclareSignalWithInterfaces<ObjectSelectionDisableSignal>();
            Container.DeclareSignalWithInterfaces<ObjectSelectionEnableSignal>();
            Container.DeclareSignalWithInterfaces<SelectedObjectPlacingRequest>();
            
            Container.BindSignal<GameStageSignal>().ToMethod<ObjectSelectionWorker>(getter => getter.OnGameStageChange).FromResolve();
            Container.BindSignal<IObjectSelectionEnableSignal>().ToMethod<ObjectSelectionEnableStack>(getter => getter.OnObjectSelectionEnable).FromResolve();
            Container.BindSignal<IObjectSelectionDisableSignal>().ToMethod<ObjectSelectionEnableStack>(getter => getter.OnObjectSelectionDisable).FromResolve();
        }
    }
}