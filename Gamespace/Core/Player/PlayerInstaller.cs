using Gamespace.Core.GameStage;
using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private PlayerSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.Bind<PlayerLocker>().AsSingle();
            Container.Bind<DarumaOtoshiStack>().AsTransient().WhenInjectedInto<PlayerLocker>();
            Container.Bind<PlayerPoolHandler>().AsSingle();
            Container.Bind<PlayerSettings>().FromInstance(_settings).AsSingle();
            Container.BindFactory<Object, Vector3, PlayModePlayer, PlayModePlayer.Factory>().FromFactory<PlayerFactory>();

            Container.DeclareSignalWithInterfaces<PlayerLockSignal>();
            Container.DeclareSignalWithInterfaces<PlayerUnlockSignal>();
            Container.DeclareSignal<PlayerSpawnRequestSignal>();
            Container.DeclareSignal<PlayerDespawnRequestSignal>();
            Container.DeclareSignal<PlayerInitializedSignal>();
            
            Container.BindSignal<IPlayerLockSignal>().ToMethod<PlayerLocker>(c => c.OnPlayerLockRequest).FromResolve();
            Container.BindSignal<IPlayerUnlockSignal>().ToMethod<PlayerLocker>(c => c.OnPlayerUnlockRequest).FromResolve();
            
            Container.BindSignal<GameStageSignal>().ToMethod<PlayerController>(c => c.OnStateChanged).FromResolve();
            Container.BindSignal<PlayerSpawnRequestSignal>().ToMethod<PlayerController>(c => c.OnPlayerSpawnRequest).FromResolve();
            Container.BindSignal<PlayerDespawnRequestSignal>().ToMethod<PlayerController>(c => c.OnPlayerDespawnRequest).FromResolve();
            Container.BindSignal<IPlayerLookAtRequestSignal>().ToMethod<PlayerController>(c => c.OnForceLookAtRequest).FromResolve();
        }
    }
}