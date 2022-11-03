using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class EditorPlayerInstaller : MonoInstaller<EditorPlayerInstaller>
    {
        [SerializeField] private EditorPlayerSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EditorPlayerController>().AsSingle();
            Container.Bind<EditorPlayerPoolHandler>().AsSingle();
            Container.Bind<EditorPlayerSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<Object, Vector3, EditorPlayer, EditorPlayer.Factory>().FromFactory<EditorPlayerFactory>();

            Container.DeclareSignal<EditorInitializedSignal>();
            Container.DeclareSignal<EditorEnableRequestSignal>();
            Container.DeclareSignal<EditorDisableRequestSignal>();
            Container.DeclareSignalWithInterfaces<EditorPlayerLookAtRequestSignal>();
            
            Container.BindSignal<GameStageSignal>().ToMethod<EditorPlayerController>(c => c.OnStateChanged).FromResolve();
            Container.BindSignal<EditorEnableRequestSignal>().ToMethod<EditorPlayerController>(c => c.OnEditorSpawnRequest).FromResolve();
            Container.BindSignal<EditorDisableRequestSignal>().ToMethod<EditorPlayerController>(c => c.OnEditorDespawnRequest).FromResolve();
            Container.BindSignal<IPlayerLookAtRequestSignal>().ToMethod<EditorPlayerController>(c => c.OnForceLookAtRequest).FromResolve();
        }
    }
}