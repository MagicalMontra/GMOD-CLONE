using UnityEngine;
using Zenject;

namespace Gamespace.Network.Register
{
    public class RegisterInstaller : MonoInstaller<RegisterInstaller>
    {
        [SerializeField] private RegisterSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RegisterController>().AsSingle();
            Container.Bind<RegisterRequestWorker>().AsSingle();
            Container.Bind<RegisterPresenter>().AsSingle();
            Container.Bind<RegisterSettings>().FromInstance(_settings).AsSingle();

            Container.BindFactory<Object, IRegisterUI, IRegisterUI.Factory>().FromFactory<IRegisterUIFactory>();
            
            Container.DeclareSignalWithInterfaces<RegisterRequestSignal>();
            Container.DeclareSignalWithInterfaces<RegisterPanelOpenSignal>();
            Container.DeclareSignalWithInterfaces<RegisterPanelCloseSignal>();
            
            Container.BindSignal<IRegisterRequestSignal>().ToMethod<RegisterController>(getter => getter.OnRegisterRequest).FromResolve();
            Container.BindSignal<IRegisterPanelOpenSignal>().ToMethod<RegisterPresenter>(getter => getter.OnRegisterPanelOpened).FromResolve();
            Container.BindSignal<RegisterPanelCloseSignal>().ToMethod<RegisterPresenter>(getter => getter.OnRegisterPanelClosed).FromResolve();
        }
    }
}