using Gamespace.Network.Register;
using Gamespace.Network.RestAPI;
using Gamespace.Utilis.Encryption;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.PlayModeTests
{
    [CreateAssetMenu(menuName = "Installer/TDD/Network Tests/Create RegisterModuleTestInstaller", fileName = "RegisterModuleTestInstaller", order = 0)]
    public class RegisterModuleTestInstaller : ScriptableObjectInstaller<RegisterModuleTestInstaller>
    {
        [SerializeField] private NetworkSettings _settings;
        public override void InstallBindings()
        {
            Container.Bind<IDataStore>().To<RESTDataStore>().AsSingle();
            Container.Bind<NetOperationErrorTranslator>().AsSingle();
            Container.BindInterfacesAndSelfTo<JsonRequest>().AsSingle();
            Container.Bind<UrlHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RESTWorker>().AsSingle();
            Container.Bind<NetworkCredential>().AsSingle();
            Container.Bind<IEncryption>().To<Base64Encryption>().AsSingle();
            Container.Bind<NetworkSettings>().FromInstance(_settings).AsSingle();
            
            Container.Bind<RegisterRequestWorker>().AsSingle();

            Container.DeclareSignalWithInterfaces<RegisterRequestSignal>();
        }
    }
}