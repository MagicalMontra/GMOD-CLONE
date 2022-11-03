using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class FloatVariableProvider
    {
        [Inject] private SignalBus _signalBus;
        private Dictionary<string, float> _values = new Dictionary<string, float>();

        public void OnFlagSet(FloatVariableFlagSetSignal signal)
        {
            if (_values.ContainsKey(signal.flagName))
            {
                _values[signal.flagName] = signal.value;
                return;
            }
            
            _values.Add(signal.flagName, signal.value);
        }
        public void OnFlagRequest(FloatVariableFlagRequestSignal signal)
        {
            var value = 0f;

            if (_values.ContainsKey(signal.flagName))
                value = _values[signal.flagName];

            _signalBus.Fire(new FloatVariableFlagResponseSignal(signal.flagName, value));
        }
    }
}