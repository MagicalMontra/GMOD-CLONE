using System.Collections;
using Cysharp.Threading.Tasks;
using Gamespace.Localization;
using Gamespace.Network.Register;
using Gamespace.Network.RestAPI;
using Gamespace.Utilis;
using nanoid;
using Zenject;
using NUnit.Framework;
using UnityEngine;

namespace Gamespace.Network.PlayModeTests
{
    [TestFixture]
    public class RegisterModuleTests : ZenjectUnitTestFixture
    {
        private string _testInstallerPath = "RegisterModuleTestInstaller";
        
        [SetUp]
        public void BindInterfaces()
        {
            SignalBusInstaller.Install(Container);
            LanguageInstaller.InstallFromResource("LanguageTestInstaller", Container);
            RegisterModuleTestInstaller.InstallFromResource(_testInstallerPath, Container);
        }
        [Test]
        [TestCase("12345", 0.6f)]
        [TestCase("123456789", 0.6f)]
        [TestCase("aA123456789", 0.8f)]
        [TestCase("aA#123456789", 1f)]
        public void PasswordIntegrityTest(string password, float expectedIntegrity)
        {
            var integrity = PasswordValidator.Value(password);
            Debug.Log(integrity);
            Assert.That(integrity == expectedIntegrity);
        }
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
        [Test(ExpectedResult = null)]
        public IEnumerator TestRegister() => UniTask.ToCoroutine(async () =>
        {
            var body = new RegisterRequestData();
            body.firstname = NanoId.Generate(6);
            body.lastname = NanoId.Generate(6);
            body.email = $"{NanoId.Generate(6)}@{NanoId.Generate(4)}.com";
            body.mobile = NanoId.Generate("0123456789", 8);
            body.password = "123456789";

            var dataStore = Container.Resolve<IDataStore>();
            var entity = await dataStore.Post<RegisterRequestData>(body, "api/account/register");
            Assert.IsTrue(entity.data.firstname == body.firstname);
        });
    }
}