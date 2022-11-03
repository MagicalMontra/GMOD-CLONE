using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginModuleInstaller : MonoInstaller<LoginModuleInstaller>
    {
        [SerializeField] private LoginSettings _settings;
        public override void InstallBindings()
        {
            Container.Bind<LoginController>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoginPlayerPrefsMapper>().AsSingle();
            Container.Bind<LoginRequestWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoginPresenter>().AsSingle();
            Container.Bind<ILoginEncryptionWorker>().To<LoginEncryptionWorker>().AsSingle();
            Container.Bind<ILoginCredentialWriter>().To<StreamLoginCredentialWriter>().AsSingle();
            Container.Bind<ILoginCredentialReader>().To<StreamLoginCredentialReader>().AsSingle();
            Container.BindFactory<Object, ILoginUI, ILoginUI.Factory>().FromFactory<ILoginUIFactory>();
            Container.BindFactory<Object, AutoLoginPromptUI, AutoLoginPromptUI.Factory>().FromFactory<AutoLoginPromptUIFactory>();
            Container.Bind<LoginSettings>().FromInstance(_settings).AsSingle();

            Container.DeclareSignal<LoginPanelCloseSignal>();
            Container.DeclareSignalWithInterfaces<LoginRequestSignal>();
            Container.DeclareSignalWithInterfaces<LoginPanelOpenSignal>();
            
            Container.BindSignal<ILoginRequestSignal>().ToMethod<LoginController>(getter => getter.OnLoginRequestSignal).FromResolve();
            Container.BindSignal<ILoginPanelOpenSignal>().ToMethod<LoginPresenter>(getter => getter.OnLoginPanelOpenRequest).FromResolve();
            Container.BindSignal<LoginPanelCloseSignal>().ToMethod<LoginPresenter>(getter => getter.OnLoginPanelCloseRequest).FromResolve();
        }
    }
}