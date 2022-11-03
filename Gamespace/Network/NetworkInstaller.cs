using Gamespace.Network.RestAPI;
using Gamespace.Utilis;
using Gamespace.Utilis.Encryption;
using UnityEngine;
using Zenject;

namespace Gamespace.Network
{
    [CreateAssetMenu(menuName = "Network/Installer", fileName = "Network Installer")]
    public class NetworkInstaller : ScriptableObjectInstaller<NetworkInstaller>
    {
        [SerializeField] private NetworkSettings _settings;
        public override void InstallBindings()
        {
            Container.Bind<IDataStore>().To<RESTDataStore>().AsSingle();
            Container.Bind<NetOperationErrorTranslator>().AsSingle();
            Container.BindInterfacesAndSelfTo<JsonRequest>().AsSingle();
            Container.Bind<UrlHandler>().AsSingle();
            Container.Bind<IRESTWorker>().To<RESTWorker>().AsSingle();
            Container.Bind<NetworkCredential>().AsSingle();
            Container.Bind<IEncryption>().To<Base64Encryption>().AsSingle();
            Container.Bind<NetworkSettings>().FromInstance(_settings).AsSingle();
        }
    }
}