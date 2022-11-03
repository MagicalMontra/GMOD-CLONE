using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPlacingLogicInstaller : MonoInstaller<ObjectPlacingLogicInstaller>
    {
        [SerializeField] private PlacingRaycastSettings _rayCastSettings;
        [SerializeField] private ObjectPlacingHintSettings _hintSettings;
        [SerializeField] private ObjectPlacingPointerSettings pointerSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObjectPlacingWorker>().AsSingle();
            Container.Bind<PlacingSurfaceMatchingWorker>().AsSingle();
            Container.Bind<IObjectPlacingPointer>().To<DefaultObjectPlacingPointer>().WhenInjectedInto<ObjectPlacingWorker>();
            Container.Bind<ObjectPlacingHintSettings>().FromInstance(_hintSettings).AsSingle();
            Container.Bind<ObjectPlacingPointerSettings>().FromInstance(pointerSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<PlacingPositionValidator>().AsSingle();
            Container.Bind<ISurfaceSelectionWorker>().To<DotsSufaceSelectionWorker>().WhenInjectedInto<PlacingPositionValidator>();
            Container.Bind<ILookSelectionWorker>().To<DotsLookSelectionWorkerCalculator>().WhenInjectedInto<DotsSufaceSelectionWorker>();
            Container.Bind<ObjectPlaceInputWorker>().AsSingle();
            Container.Bind<ObjectPlaceExitInputWorker>().AsSingle();
            Container.Bind<ObjectPlacingControls>().AsSingle();
            Container.Bind<PlacingRaycastSettings>().FromInstance(_rayCastSettings).AsSingle();
            Container.BindFactory<Object, IPlaceableObject, IPlaceableObject.Factory>().FromFactory<PlaceableObjectFactory>();
            
            ObjectPlacingLogicSignalInstaller.Install(Container);
        }
    }
}