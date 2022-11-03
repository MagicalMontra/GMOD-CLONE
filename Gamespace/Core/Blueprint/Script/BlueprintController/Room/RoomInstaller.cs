using Gamespace.Core.Blueprint.Room;
using Zenject;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomInstaller : Installer<RoomInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RoomController>().AsSingle();
            Container.Bind<RoomProvider>().AsSingle();
            Container.Bind<IRoomSelector>().To<RoomMouseRaycastSelector>().AsSingle();
            Container.Bind<RoomMovementWorker>().AsSingle();

            Container.Bind<RoomSelectionInputWorker>().AsSingle();

            Container.Bind<RoomRotateInputWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoomRotateWorker>().AsSingle();

            Container.Bind<RoomRemoveInputWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoomRemoveWorker>().AsSingle();

            Container.DeclareSignal<RoomRequestSignal>();
            Container.DeclareSignal<RoomResponseSignal>();
            Container.DeclareSignal<RoomInitializeSignal>();
            Container.DeclareSignal<RoomDisposeRequestSignal>();
            Container.DeclareSignal<RoomDisposeResponseSignal>();
            
            Container.BindSignal<RoomRequestSignal>().ToMethod<RoomProvider>(getter => getter.OnRoomRequested).FromResolve();
            Container.BindSignal<RoomInitializeSignal>().ToMethod<RoomProvider>(getter => getter.OnRoomInitialized).FromResolve();
            Container.BindSignal<RoomDisposeRequestSignal>().ToMethod<RoomProvider>(getter => getter.OnRoomDeinitialized).FromResolve();
        }
    }

}
