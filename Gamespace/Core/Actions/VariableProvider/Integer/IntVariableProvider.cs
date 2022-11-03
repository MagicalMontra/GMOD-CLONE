using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class IntVariableProvider
    {
        [Inject] private SignalBus _signalBus;
        private Dictionary<string, int> _values = new Dictionary<string, int>();

        public void OnFlagSet(IntVariableFlagSetSignal signal)
        {
            if (_values.ContainsKey(signal.flagName))
            {
                _values[signal.flagName] = signal.value;
                return;
            }
            
            _values.Add(signal.flagName, signal.value);
        }
        public void OnFlagRequest(IntVariableFlagRequestSignal signal)
        {
            var value = 0;

            if (_values.ContainsKey(signal.flagName))
                value = _values[signal.flagName];

            _signalBus.Fire(new IntVariableFlagResponseSignal(signal.flagName, value));
        }
    }
}