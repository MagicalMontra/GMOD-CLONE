using System;
using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class IntFlagRequestActionBehaviour : VoidActionBehaviour
    {
        public StringActionVariable flagName;

        public override void OnConstruct()
        {
            _signalBus.Subscribe<IntVariableFlagResponseSignal>(OnFlagGet);
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
            _signalBus.Fire(new IntVariableFlagRequestSignal(flagName.value));
        }
        private void OnFlagGet(IntVariableFlagResponseSignal signal)
        {
            if (flagName.value != signal.flagName)
                return;
            
            Next(signal.value);
        }
    }
}