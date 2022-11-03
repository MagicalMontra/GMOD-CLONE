using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Gamespace.Core.Actions
{
    public class ActionProvider : IActionProvider
    {
        private List<IActionBehaviour> _behaviours = new List<IActionBehaviour>();
        public void OnActionInitialized(ActionInitializeSignal signal)
        {
            if (!_behaviours.Exists(behaviour => behaviour.id == signal.behaviour.id))
                _behaviours.Add(signal.behaviour);
        }
        public void GetLinkedAction(FindLinkedActionSignal signal)
        {
            GetLinkedAction(signal.behaviour).Forget();
        }
        private async UniTaskVoid GetLinkedAction(IActionBehaviour behaviour)
        {
            var index = _behaviours.FindIndex(b => b.id == behaviour.id);
            
            if (index < 0)
                await UniTask.Delay(5000);
            
            index = _behaviours.FindIndex(b => b.id == behaviour.id);

            if (index < 0)
            {
                await UniTask.Yield();
                return;
            }
            
            // behaviour.AssignNextAction(, _behaviours[index]);
        }
    }
}