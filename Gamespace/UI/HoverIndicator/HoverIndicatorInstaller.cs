using UnityEngine;
using Zenject;

namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorInstaller : MonoInstaller<HoverIndicatorInstaller>
    {
        [SerializeField] private HoverIndicatorSettings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HoverIndicatorWorker>().AsSingle();
            Container.Bind<HoverIndicatorSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<Object, Transform, IHoverIndicator, IHoverIndicator.Factory>().FromFactory<HoverIndicatorFactory>();

            Container.DeclareSignal<HoverIndicatorCancelSignal>();
            Container.DeclareSignal<HoverIndicatorRequestSignal>();
            
            Container.BindSignal<HoverIndicatorCancelSignal>().ToMethod<HoverIndicatorWorker>(getter => getter.OnIndicatorCancel).FromResolve();
            Container.BindSignal<HoverIndicatorRequestSignal>().ToMethod<HoverIndicatorWorker>(getter => getter.OnIndicatorRequest).FromResolve();
        }
    }
}