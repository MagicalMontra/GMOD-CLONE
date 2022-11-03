using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class StringVariableProvider
    {
        [Inject] private SignalBus _signalBus;
        private Dictionary<string, string> _values = new Dictionary<string, string>();

        public void OnFlagSet(StringVariableFlagSetSignal signal)
        {
            if (_values.ContainsKey(signal.flagName))
            {
                _values[signal.flagName] = signal.value;
                return;
            }
            
            _values.Add(signal.flagName, signal.value);
        }
        public void OnFlagRequest(StringVariableFlagRequestSignal signal)
        {
            var value = "";

            if (_values.ContainsKey(signal.flagName))
                value = _values[signal.flagName];

            _signalBus.Fire(new StringVariableFlagResponseSignal(signal.flagName, value));
        }
    }
}