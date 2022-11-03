using Gamespace.Core.GameStage;
using Zenject;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPlacingLogicSignalInstaller : Installer<ObjectPlacingLogicSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlacingExitResponseSignal>();
            Container.DeclareSignal<PlaceableSurfaceResponseSignal>();

            Container.BindSignal<IPlaceablePanelOpenSignal>().ToMethod<ObjectPlacingWorker>(getter => getter.OnPlaceableUIOpened).FromResolve();
            Container.BindSignal<INewPlacingRequestSignal>().ToMethod<ObjectPlacingWorker>(getter => getter.OnNewPlacingRequest).FromResolve();
            Container.BindSignal<IPlacingRequestSignal>().ToMethod<ObjectPlacingWorker>(getter => getter.OnPlacingRequest).FromResolve();
            Container.BindSignal<PlaceableSurfaceResponseSignal>().ToMethod<ObjectPlacingWorker>(getter => getter.OnPlaceableSurfaceResponse).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<ObjectPlacingWorker>(getter => getter.OnGameStageChange).FromResolve();
        }
    }
}