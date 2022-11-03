using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelMenuInstaller : MonoInstaller<CircleWheelMenuInstaller>
    {
        [SerializeField] private CircleWheelSettings _settings;
        [SerializeField] private WheelButtonDatabase _database;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CircleWheelMenuController>().AsSingle();
            Container.Bind<CircleWheelButtonWorker>().AsSingle();
            Container.Bind<CircleMiddleWorker>().AsSingle();
            Container.Bind<CircleWheelSegmentWorker>().AsSingle();
            Container.Bind<CircleWheelExitInputWorker>().AsSingle();
            Container.Bind<CircleWheelMouseExecuteInputWorker>().AsSingle();
            Container.Bind<CircleWheelMousePositionInputWorker>().AsSingle();
            Container.Bind<CircleWheelPageChangeInputWorker>().AsSingle();
            Container.Bind<CircleWheelColorWorker>().AsSingle();
            Container.Bind<CircleWheelRotationWorker>().AsSingle();
            Container.Bind<CircleWheelPageWorker>().AsSingle();
            Container.Bind<ICircleWheelOpenAnimationWorker>().To<CircleWheelOpenDotweenAnimationWorker>().AsSingle();
            Container.Bind<ICircleWheelCloseAnimationWorker>().To<CircleWheelCloseDotweenAnimationWorker>().AsSingle();
            Container.Bind<CircleWheelMenuControls>().AsSingle();
            Container.Bind<CircleWheelSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<WheelButtonDatabase>().FromInstance(_database).AsSingle();
            
            Container.BindMemoryPool<WheelSegment, WheelSegment.Pool>().WithInitialSize(1).FromComponentInNewPrefab(_settings.separatorPrefab).UnderTransformGroup("CircleWheelSeparatorPool");
            Container.BindMemoryPool<ExtendedWheelButton, ExtendedWheelButton.Pool>().WithInitialSize(2).FromComponentInNewPrefab(_settings.buttonPrefab).UnderTransformGroup("CircleWheelButtonPool");

            Container.DeclareSignalWithInterfaces<CircleWheelOpenSignal>();
            Container.DeclareSignalWithInterfaces<CircleWheelCloseSignal>();
            
            Container.BindSignal<ICircleWheelOpenSignal>().ToMethod<CircleWheelMenuController>(getter => getter.OnCircleWheelOpened).FromResolve();
            Container.BindSignal<ICircleWheelCloseRequest>().ToMethod<CircleWheelMenuController>(getter => getter.CircleWheelCloseRequested).FromResolve();
        }
    }
}