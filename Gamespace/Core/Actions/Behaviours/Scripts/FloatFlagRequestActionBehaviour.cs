using System;
using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class FloatFlagRequestActionBehaviour : VoidActionBehaviour
    {
        public StringActionVariable flagName;

        public override void OnConstruct()
        {
            _signalBus.Subscribe<FloatVariableFlagResponseSignal>(OnFlagGet);
        }
        public override Type[] GetAcceptingTypes()
        {
            var types = new List<Type>
            {
                typeof(IntActionBehaviour), 
                typeof(FloatActionBehaviour), 
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ flagName };
        }
        public override void Perform()
        {
            _signalBus.Fire(new FloatVariableFlagRequestSignal(flagName.value));
        }
        private void OnFlagGet(FloatVariableFlagResponseSignal signal)
        {
            if (flagName.value != signal.flagName)
                return;
            
            Next(signal.value);
        }
    }
}