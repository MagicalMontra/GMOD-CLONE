using Gamespace.Network;
using Zenject;
using NUnit.Framework;
using Gamespace.Network.RestAPI;
using UnityEngine;

namespace Gamespace.Network.Tests
{
    [TestFixture]
    public class UrlTests : ZenjectUnitTestFixture
    {
        private string _testInstallerPath = "UrlTestInstaller";
        
        [SetUp]
        public void BindInterfaces()
        {
            UrlTestInstaller.InstallFromResource(_testInstallerPath, Container);
        }
        [Test]
        public void WillUrlHandlerResolve()
        {
            var obj = Container.Resolve<UrlHandler>();
            Assert.NotNull(obj);
        }
        [Test]
        public void WillNetworkSettingsResolve()
        {
            var settings = Container.Resolve<NetworkSettings>();
            Assert.NotNull(settings);
        }
        [Test]
        public void LocalHostTests()
        {
            var urlHandler = Container.Resolve<UrlHandler>();
            var settings = Container.Resolve<NetworkSettings>();
    
            var response= urlHandler.Handle("");
            //NOTE: Intentionally 
            // Assert.That(response, Does.Contain("localhost"));  
            
            Assert.That(response, !Does.Contain("localhost"));  
            Debug.Log(response);
        }
        [Test]
        public void GateWayTests()
        {
            var urlHandler = Container.Resolve<UrlHandler>();
            var settings = Container.Resolve<NetworkSettings>();
    
            var response= urlHandler.Handle("");
            Assert.That(response, Does.Contain(settings.urlGateWay.Value));
            Debug.Log(response);
        }
        [Test]
        public void PortTests()
        {
            var urlHandler = Container.Resolve<UrlHandler>();
            var settings = Container.Resolve<NetworkSettings>();
    
            var response= urlHandler.Handle("");
            Assert.That(response, Does.Contain(settings.apiPort.Value.ToString()));
            Debug.Log(response);
        }
    }
}