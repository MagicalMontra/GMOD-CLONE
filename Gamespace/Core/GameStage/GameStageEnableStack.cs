using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.GameStage
{
    public class GameStageEnableStack
    {
        public bool isEnabled => _stack.count <= 0;
        [Inject] private DarumaOtoshiStack _stack;
        
        public void OnGameStageEnable(IGameStageEnableSignal signal)
        {
            _stack.Hit(signal.id);
            
#if UNITY_EDITOR
            // Debug.Log($"{signal.id} removed to daruma body");
            // Debug.Log($"daruma body count: {_stack.count}");
#endif
        }
        public void OnGameStageDisable(IGameStageDisableSignal signal)
        {
            _stack.Add(signal.id);
            
#if UNITY_EDITOR
            // Debug.Log($"{signal.id} add to daruma body");
            // Debug.Log($"daruma body count: {_stack.count}");
#endif
        }
    }
}