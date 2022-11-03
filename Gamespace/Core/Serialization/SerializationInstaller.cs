using Zenject;
using UnityEngine;
using Gamespace.Core.ObjectMode;
using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.Serialization
{
    public class SerializationInstaller : MonoInstaller<SerializationInstaller>
    {
        [SerializeField] private SerializableDatabase _database;
        [SerializeField] private SerializationSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SerializationController>().AsSingle();
            Container.Bind<SerializeSequenceWorker>().AsSingle();
            Container.Bind<ISerializationWriter>().To<SerializationWriter>().AsSingle();
            Container.Bind<DeserializeSequenceWorker>().AsSingle();
            Container.BindFactory<string, RoomBase, SerializeRoomFactory>().FromFactory<SerializeReferenceFactory<RoomBase>>();
            Container.BindFactory<string, IPlaceableObject, SerializePlaceableFactory>().FromFactory<SerializeReferenceFactory<IPlaceableObject>>();
            Container.Bind<SerializableDatabase>().FromInstance(_database).AsSingle();
            Container.Bind<SerializationSettings>().FromInstance(_settings).AsSingle();

            Container.DeclareSignal<SerializeRequestSignal>();
            Container.DeclareSignal<DeserializeRequestSignal>();
            
            Container.BindSignal<SerializeRequestSignal>().ToMethod<SerializationController>(getter => getter.OnSerializeRequest).FromResolveAll();
            Container.BindSignal<DeserializeRequestSignal>().ToMethod<SerializationController>(getter => getter.OnDeserializeRequest).FromResolveAll();

            Container.BindSignal<RoomSerializeResponseSignal>().ToMethod<SerializeSequenceWorker>(getter => getter.OnRoomSerializeResponse).FromResolveAll();
            Container.BindSignal<PlaceableSerializeResponseSignal>().ToMethod<SerializeSequenceWorker>(getter => getter.OnPlaceableSerializeResponse).FromResolveAll();
            
            Container.BindSignal<PlaceableDisposeResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnPlaceableDisposeResponse).FromResolveAll();
            Container.BindSignal<RoomDeserializeResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnRoomDeserializeResponse).FromResolveAll();
            Container.BindSignal<PlaceableSurfaceDisposeResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnPlaceableSurfaceDisposeResponse).FromResolveAll();
            Container.BindSignal<RoomDisposeResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnRoomDisposeResponse).FromResolveAll();
            Container.BindSignal<PlaceableSurfaceResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnPlaceableSurfaceResponse).FromResolveAll();
            Container.BindSignal<PlaceableDeserializeResponseSignal>().ToMethod<DeserializeSequenceWorker>(getter => getter.OnPlaceableDeserializeResponse).FromResolveAll();
        }
    }
}