using System.Collections;
using Cysharp.Threading.Tasks;
using Gamespace.Network.Login;
using Gamespace.Network.RestAPI;
using Gamespace.Localization;
using Zenject;
using NUnit.Framework;

namespace Gamespace.Network.PlayModeTests
{
    [TestFixture]
    public class LoginModuleTests : ZenjectUnitTestFixture
    {
        private string _testInstallerPath = "LoginModuleTestInstaller";
        
        [SetUp]
        public void BindInterfaces()
        {
            SignalBusInstaller.Install(Container);
            LanguageInstaller.InstallFromResource("LanguageTestInstaller", Container);
            LoginModuleTestInstaller.InstallFromResource(_testInstallerPath, Container);
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
        public IEnumerator TestLogin() => UniTask.ToCoroutine(async () =>
        {
            var body = new LoginRequestData();
            body.email = "test1@gamespaceinc.com";
            body.password = "tT123456";
            var dataStore = Container.Resolve<IDataStore>();
            var entity = await dataStore.Post<AccessToken>(body, "api/account/login");
            Assert.IsFalse(entity.error.statusCode != 0);
        });
    }
}
