using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Rotation;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class ObjectElevationInstaller : MonoInstaller<ObjectElevationInstaller>
    {
        [SerializeField] private ObjectElevationSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObjectElevationWorker>().AsSingle();
            Container.Bind<ObjectElevationSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<ObjectElevationIndicatorWorker>().AsSingle();
            Container.Bind<ObjectElevateExitInputWorker>().AsSingle();
            Container.Bind<ObjectElevateResetInputWorker>().AsSingle();
            Container.Bind<ObjectElevateDescendInputWorker>().AsSingle();
            Container.Bind<ObjectElevationControls>().AsSingle();

            Container.DeclareSignal<ObjectElevationExitRequestSignal>();
            Container.DeclareSignal<ObjectElevationExitResponseSignal>();
            Container.DeclareSignalWithInterfaces<ObjectElevationRequestSignal>();

            Container.BindSignal<IObjectElevationRequestSignal>().ToMethod<ObjectElevationWorker>(getter => getter.OnObjectElevationRequest).FromResolve();
            Container.BindSignal<ObjectElevationExitRequestSignal>().ToMethod<ObjectElevationWorker>(getter => getter.OnObjectElevationExitRequested).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<ObjectElevationWorker>(getter => getter.OnGameStageChange).FromResolve();
        }
    }
}