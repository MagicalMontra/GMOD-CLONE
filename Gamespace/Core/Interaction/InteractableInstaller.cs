using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Interaction
{
    public class InteractableInstaller : MonoInstaller<InteractableInstaller>
    {
        [SerializeField] private InteractableSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InteractableWorker>().AsSingle();
            Container.Bind<IInteractableSelector>().To<DotProductInteractableSelector>().AsSingle();
            Container.Bind<InteracableInputWorker>().AsSingle();
            Container.Bind<InteractionInputControl>().AsSingle();
            Container.BindInterfacesAndSelfTo<InteractableProvider>().AsSingle();
            Container.Bind<InteractableDistanceBiasWorker>().AsSingle();

            Container.Bind<InteractableSettings>().FromInstance(_settings).AsSingle();

            PullInstaller.Install(Container);

            Container.DeclareSignal<InteractableDisposeSignal>();
            Container.DeclareSignal<InteractableInitializeSignal>();

            Container.BindSignal<GameStageSignal>().ToMethod<InteractableWorker>(getter => getter.OnGameStageChanged).FromResolve();
            Container.BindSignal<InteractableDisposeSignal>().ToMethod<InteractableProvider>(getter => getter.OnInteractableDisposed).FromResolve();
            Container.BindSignal<InteractableInitializeSignal>().ToMethod<InteractableProvider>(getter => getter.OnInteractableInitialized).FromResolve();
        }
    }
}
