using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionInstaller : MonoInstaller<ActionInstaller>
    {
        [SerializeField] private ActionSettings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ActionPropertyWorker>().AsSingle();
            Container.Bind<SliderActionPropertyElementPoolWorker>().AsSingle();
            Container.Bind<InputFieldActionPropertyElementPoolWorker>().AsSingle();
            Container.Bind<IActionPropertyPanelSetActive>().To<ActionPropertyPanelSetActive>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActionPropertyExitInputWorker>().AsSingle();
            
            
            Container.BindInterfacesAndSelfTo<ActionLinkWorker>().AsSingle();
            Container.Bind<IActionTypeMatching>().To<ActionAbstractTypeMatching>().AsSingle();
            Container.Bind<ActionLinkCommitInputWorker>().AsSingle();
            Container.Bind<ActionLinkCancelInputWorker>().AsSingle();
            Container.BindFactory<Object, ActionLinkRenderer, ActionLinkRenderer.Factory>().FromFactory<ActionLinkRendererFactory>();
            Container.Bind<ActionInputControls>().AsSingle();
            Container.Bind<ActionSettings>().FromInstance(_settings).AsSingle();
            
            Container.BindMemoryPool<SliderActionPropertyUIElement, SliderActionPropertyUIElement.Pool>().WithInitialSize(1).FromComponentInNewPrefab(_settings.sliderUIElementPrefab).UnderTransform(_settings.sliderPoolTransform);
            Container.BindMemoryPool<InputFieldActionPropertyUIElement, InputFieldActionPropertyUIElement.Pool>().WithInitialSize(1).FromComponentInNewPrefab(_settings.inputFieldUIElementPrefab).UnderTransform(_settings.inputFieldPoolTransform);

            Container.DeclareSignal<ActionLinkSignal>();
            Container.DeclareSignal<ActionPropertyRequestSignal>();
            
            Container.BindSignal<ActionLinkSignal>().ToMethod<ActionLinkWorker>(getter => getter.OnActionLinkFired).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<ActionPropertyWorker>(getter => getter.OnGameStageChanged).FromResolve();
            Container.BindSignal<ActionPropertyRequestSignal>().ToMethod<ActionPropertyWorker>(getter => getter.OnActionPropertyRequest).FromResolve();
        }
    }
}