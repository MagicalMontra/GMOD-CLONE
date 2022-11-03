using Zenject;
using UnityEngine;
using Gamespace.Core.Serialization;

namespace Gamespace.Core.ObjectMode.Serialization
{
    public class PlaceableObjectSerializationInstaller : MonoInstaller<PlaceableObjectSerializationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlaceableObjectSerializer>().AsSingle();
            Container.Bind<PlaceableObjectDeserializer>().AsSingle();

            Container.BindFactory<Object, IPlaceableObject, PlaceholderFactory<Object, IPlaceableObject>>().FromFactory<PrefabFactory<IPlaceableObject>>();

            Container.Bind<ISerializationQueueWorker<ObjectData>>().To<LocalObjectSerializationQueueWorker>().WhenInjectedInto<PlaceableObjectSerializer>();
            Container.Bind<ISerializationReader<ObjectData>>().To<LocalObjectSerializationReader>().WhenInjectedInto<PlaceableObjectDeserializer>();

            Container.DeclareSignal<PlaceableSerializeRequestSignal>();
            Container.DeclareSignal<PlaceableSerializeResponseSignal>();
            Container.DeclareSignal<PlaceableDeserializeRequestSignal>();
            Container.DeclareSignal<PlaceableDeserializeResponseSignal>();
            
            Container.BindSignal<PlaceableSerializeRequestSignal>().ToMethod<PlaceableObjectSerializer>(getter => getter.OnSerializeRequest).FromResolve();
            Container.BindSignal<PlaceableObjectReponseSignal>().ToMethod<PlaceableObjectSerializer>(getter => getter.OnPlaceableProviderResponse).FromResolve();
            Container.BindSignal<PlaceableDeserializeRequestSignal>().ToMethod<PlaceableObjectDeserializer>(getter => getter.OnDeserializeRequest).FromResolve();
        }
    }
}