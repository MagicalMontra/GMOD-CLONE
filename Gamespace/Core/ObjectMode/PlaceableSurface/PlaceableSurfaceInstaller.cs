using Zenject;
using Gamespace.Core.ObjectMode.Placing;

namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public class PlaceableSurfaceInstaller : Installer<PlaceableSurfaceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlaceableSurfaceWorker>().AsSingle();

            Container.DeclareSignal<PlaceableSurfaceResponseSignal>();
            Container.DeclareSignal<PlaceableSurfaceInitializeSignal>();
            Container.DeclareSignal<PlaceableSurfaceDisposeRequestSignal>();
            Container.DeclareSignal<PlaceableSurfaceDisposeResponseSignal>();
            Container.DeclareSignalWithInterfaces<PlaceableSurfaceRequestSignal>();
            
            Container.BindSignal<PlaceableSurfaceInitializeSignal>().ToMethod<PlaceableSurfaceWorker>(getter => getter.OnSurfaceInitialized).FromResolve();
            Container.BindSignal<PlaceableSurfaceDisposeRequestSignal>().ToMethod<PlaceableSurfaceWorker>(getter => getter.OnSurfaceDisposed).FromResolve();
            Container.BindSignal<IPlaceableSurfaceRequestSignal>().ToMethod<PlaceableSurfaceWorker>(getter => getter.OnSurfaceRequested).FromResolve();
        }
    }
}