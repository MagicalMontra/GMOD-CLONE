namespace Gamespace.Core.Actions
{
    public class FindLinkedActionSignal
    {
        public IActionBehaviour behaviour => _behaviour;
        private IActionBehaviour _behaviour;
        
        public FindLinkedActionSignal(IActionBehaviour behaviour)
        {
            _behaviour = behaviour;
        }
    }

    public class ActionInitializeSignal
    {
        public IActionBehaviour behaviour => _behaviour;
        private IActionBehaviour _behaviour;

        public ActionInitializeSignal(IActionBehaviour behaviour)
        {
            _behaviour = behaviour;
        }
    }
}