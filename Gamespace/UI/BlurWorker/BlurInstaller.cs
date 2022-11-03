using LeTai.Asset.TranslucentImage;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    [CreateAssetMenu(menuName = "Installer/Create BlurInstaller", fileName = "BlurInstaller", order = 0)]
    public class BlurInstaller : ScriptableObjectInstaller<BlurInstaller>
    {
        [SerializeField] private BlurStackSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BlurWorker>().AsSingle();
            Container.Bind<BlurStackSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<ScalableBlurConfig, BlurStackWorker, BlurStackWorker.Factory>().FromFactory<BlurStackWorkerFactory>();

            Container.DeclareSignal<BlurBeginRequestSignal>();
            Container.DeclareSignal<BlurCancelRequestSignal>();

            Container.BindSignal<BlurBeginRequestSignal>().ToMethod<BlurWorker>(getter => getter.OnBlurBeginRequest).FromResolve();
            Container.BindSignal<BlurCancelRequestSignal>().ToMethod<BlurWorker>(getter => getter.OnBlurCancelRequest).FromResolve();
        }
    }
}