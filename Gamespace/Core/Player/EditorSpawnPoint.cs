using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class EditorSpawnPoint : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        public void SpawnEditor()
        {
            _signalBus.Fire(new EditorEnableRequestSignal(transform.position));
        }
    }
}