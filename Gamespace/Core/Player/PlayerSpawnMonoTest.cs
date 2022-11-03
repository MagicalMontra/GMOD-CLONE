using Cysharp.Threading.Tasks;
using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Player
{
    public class PlayerSpawnMonoTest : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPos;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GameStageSignal>(OnPlayModeSelected);
        }
        private void OnPlayModeSelected(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play)
                SpawnPlayer().Forget();
        }
        private async UniTaskVoid SpawnPlayer()
        {
            await UniTask.Delay(100);
            
            _signalBus.Fire(new PlayerSpawnRequestSignal(_spawnPos.position));

            await UniTask.Yield();
        }
    }
}