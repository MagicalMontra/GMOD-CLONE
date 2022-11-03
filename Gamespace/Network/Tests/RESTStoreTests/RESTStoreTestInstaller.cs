using Gamespace.Network;
using Gamespace.Network.RestAPI;
using Gamespace.Utilis.Encryption;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Tests
{
    [CreateAssetMenu(menuName = "Installer/TDD/Network Tests/Create RESTStoreTest", fileName = "UrlTestInstaller", order = 0)]
    public class RESTStoreTestInstaller : ScriptableObjectInstaller<RESTStoreTestInstaller>
    {
        [SerializeField] private NetworkSettings _settings;
    
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.Bind<IDataStore>().To<RESTDataStore>().AsSingle();
            Container.Bind<NetOperationErrorTranslator>().AsSingle();
            Container.Bind<TokenRenewer>().AsSingle();
            Container.BindInterfacesAndSelfTo<JsonRequest>().AsSingle();
            Container.Bind<UrlHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RESTWorker>().AsSingle();
            Container.Bind<NetworkCredential>().AsSingle();
            Container.Bind<IEncryption>().To<Base64Encryption>().AsSingle();
            Container.Bind<NetworkSettings>().FromInstance(_settings).AsSingle();
        }
    }
}
