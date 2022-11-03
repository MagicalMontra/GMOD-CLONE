using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ObjectRotationInstaller : MonoInstaller<ObjectRotationInstaller>
    {
        [SerializeField] private ObjectRotationSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObjectRotationWorker>().AsSingle();
            Container.Bind<IRotateAxisIndicator>().To<DefaultRotateAxisIndicator>().AsSingle();
            Container.Bind<ObjectRotationSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<ObjectRotationExitInputWorker>().AsSingle();
            Container.Bind<ObjectRotationResetInputWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectRotationRotateInputWorker>().AsSingle();
            Container.Bind<ObjectRotationAxisSwitchInputWorker>().AsSingle();
            Container.Bind<ObjectRotateControls>().AsSingle();

            Container.DeclareSignalWithInterfaces<PlaceableRotateExitRequestSignal>();
            Container.DeclareSignalWithInterfaces<PlaceableRotateRequestSignal>();

            Container.BindSignal<IRotationRequestSignal>().ToMethod<ObjectRotationWorker>(getter => getter.OnRotationRequestSignal).FromResolve();
            Container.BindSignal<PlaceableRotateExitRequestSignal>().ToMethod<ObjectRotationWorker>(getter => getter.OnRotationExitRequested).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<ObjectRotationWorker>(getter => getter.OnGameStageChange).FromResolve();
        }
    }
}