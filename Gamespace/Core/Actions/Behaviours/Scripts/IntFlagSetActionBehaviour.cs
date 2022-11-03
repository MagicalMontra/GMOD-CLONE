using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class IntFlagSetActionBehaviour : IntActionBehaviour
    {
        [SerializeField] private StringActionVariable flagName;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ flagName };
        }
        public override void Perform(int value)
        {
            _signalBus.Fire(new IntVariableFlagSetSignal(flagName.value, value));
            Next(value);
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
    }
}