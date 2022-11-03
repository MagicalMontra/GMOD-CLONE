using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Zenject;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using Gamespace.Network.RestAPI;

namespace Gamespace.Network.Tests
{
    [TestFixture]
    public class RESTStoreTests : ZenjectUnitTestFixture
    {
        private string _testInstallerPath = "RESTStoreTestInstaller";
        
        [SetUp]
        public void BindInterfaces()
        {
            RESTStoreTestInstaller.InstallFromResource(_testInstallerPath, Container);
        }

        #region ResolveTests
        [Test]
        public void WillIRequestHandlerResolve()
        {
            var IRequestHandler = Container.Resolve<IRequestHandler<object>>();
            Assert.NotNull(IRequestHandler);
        }
        [Test]
        public void WillUrlHandlerResolve()
        {
            var urlHandler = Container.Resolve<UrlHandler>();
            Assert.NotNull(urlHandler);
        }
        [Test]
        public void WillRESTWorkerResolve()
        {
            var IRESTWorker = Container.Resolve<IRESTWorker>();
            Assert.NotNull(IRESTWorker);
        }
        [Test]
        public void WillNetworkCredentialResolve()
        {
            var networkCredential = Container.Resolve<NetworkCredential>();
            Assert.NotNull(networkCredential);
        }
        [Test]
        public void WillNetworkSettingsResolve()
        {
            var networkSettings = Container.Resolve<NetworkSettings>();
            Assert.NotNull(networkSettings);
        }
        [Test]
        public void WillDataStoreResolve()
        {
            var dataStore = Container.Resolve<IDataStore>();
            Assert.NotNull(dataStore);
        }
        [Test]
        public void WillJsonRequestResolve()
        {
            var jsonRequest = Container.Resolve<JsonRequest>();
            Assert.NotNull(jsonRequest);
        }
        #endregion

        [Test(ExpectedResult = null)]
        public IEnumerator TestConnection() => UniTask.ToCoroutine(async () =>
        {
            var expectedResult = "{\"Message\":\"The Gamespace API V1.0\"}";
            var jsonRequest = Container.Resolve<JsonRequest>();
            var restWorker = Container.Resolve<IRESTWorker>();
            var urlHandler = Container.Resolve<UrlHandler>();
            var url = urlHandler.Handle("", HttpUtility.ParseQueryString(""));
            var request = jsonRequest.CreateRequest(url, "GET");
            var json = await restWorker.Handle(request);
            Assert.IsTrue(json == expectedResult);
        });
    }
}