using Gamespace.Network;
using Gamespace.Network.RestAPI;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Tests
{
    [CreateAssetMenu(menuName = "Installer/TDD/Network Tests/Create UrlTest", fileName = "UrlTestInstaller", order = 0)]
    public class UrlTestInstaller : ScriptableObjectInstaller<UrlTestInstaller>
    {
        [SerializeField] private NetworkSettings _settings;

        public override void InstallBindings()
        {
            Container.Bind<UrlHandler>().AsSingle();
            Container.Bind<NetworkSettings>().FromInstance(_settings).AsSingle();
        }
    }
}