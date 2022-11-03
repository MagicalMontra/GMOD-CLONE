using System;
using System.Collections.Generic;

namespace Gamespace.Core.Actions
{
    public class FloatFlagSetActionBehaviour : FloatActionBehaviour
    {
        public StringActionVariable flagName;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ flagName };
        }
        public override void Perform(float value)
        {
            _signalBus.Fire(new FloatVariableFlagSetSignal(flagName.value, value));
            Next(value);
        }
        public override Type[] GetAcceptingTypes()
        {
            var types = new List<Type>
            {
                typeof(IntActionBehaviour),
                typeof(VoidActionBehaviour),
                typeof(FloatActionBehaviour),
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
    }
}