using UnityEngine;
using Zenject;

namespace Gamespace.UI.Gauge
{
    public class GaugeInstaller : MonoInstaller
    {
        [SerializeField] private GaugeHudSetting _gaugeHudSetting;
        [SerializeField] private GaugeTypeSettings _typeSettings;
        public override void InstallBindings()
        {
            Container.Bind<GaugeHudWorker>().AsSingle();
            Container.Bind<GaugeTypeSelector>().AsSingle();
            Container.Bind<GaugeTypeSettings>().FromInstance(_typeSettings).AsSingle();
            Container.BindFactory<GameObject, Transform, IGaugeUI, IGaugeUI.Factory>().FromFactory<GameObjectGaugeUIFactory>();
            Container.Bind<GaugeHudSetting>().FromInstance(_gaugeHudSetting).AsSingle();

            Container.DeclareSignal<GaugeRequestSignal>();
            Container.DeclareSignal<GaugeResponseSignal>();

            Container.BindSignal<GaugeRequestSignal>().ToMethod<GaugeHudWorker>(getter => getter.OnGaugeRequest).FromResolve();
        }
    }
}
