using Gamespace.Utilis;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionEnableStack
    {
        public bool isEnabled => _stack.count <= 0;
        [Inject] private DarumaOtoshiStack _stack;
        
        public void OnObjectSelectionEnable(IObjectSelectionEnableSignal signal)
        {
            _stack.Hit(signal.id);
            
// #if UNITY_EDITOR
             // Debug.Log($"{signal.id} removed to daruma body");
             // Debug.Log($"daruma body count: {_stack.count}");
// #endif
        }
        public void OnObjectSelectionDisable(IObjectSelectionDisableSignal signal)
        {
            _stack.Add(signal.id);
            
// #if UNITY_EDITOR
             // Debug.Log($"{signal.id} add to daruma body");
             // Debug.Log($"daruma body count: {_stack.count}");
// #endif
        }
    }
}