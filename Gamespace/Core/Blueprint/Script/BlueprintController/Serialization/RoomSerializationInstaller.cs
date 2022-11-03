using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.ObjectMode;
using Gamespace.Core.Serialization;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint.Serialization
{
    public class RoomSerializationInstaller : MonoInstaller<RoomSerializationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<RoomSerializer>().AsSingle();
            Container.Bind<RoomDeserializer>().AsSingle();

            Container.BindFactory<Object, RoomBase, PlaceholderFactory<Object, RoomBase>>().FromFactory<PrefabFactory<RoomBase>>();

            Container.Bind<ISerializationQueueWorker<RoomData>>().To<LocalRoomSerializationQueueWorker>().WhenInjectedInto<RoomSerializer>();
            Container.Bind<ISerializationReader<RoomData>>().To<LocalRoomDeserializationReader>().WhenInjectedInto<RoomDeserializer>();
            
            Container.DeclareSignal<RoomDeserializeRequestSignal>();
            Container.DeclareSignal<RoomDeserializeResponseSignal>();
            Container.DeclareSignal<RoomSerializeRequestSignal>();
            Container.DeclareSignal<RoomSerializeResponseSignal>();
            
            Container.BindSignal<RoomResponseSignal>().ToMethod<RoomSerializer>(getter => getter.OnRoomResponse).FromResolve();
            Container.BindSignal<RoomSerializeRequestSignal>().ToMethod<RoomSerializer>(getter => getter.OnSerializeRequest).FromResolve();
            Container.BindSignal<RoomDeserializeRequestSignal>().ToMethod<RoomDeserializer>(getter => getter.OnDeserializeRequest).FromResolve();
        }
    }
}