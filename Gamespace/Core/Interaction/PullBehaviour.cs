using System;
using System.Collections.Generic;
using Gamespace.Core.Actions;

namespace Gamespace.Core.Interaction
{
    public class PullBehaviour : FloatActionBehaviour
    {
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
        }
        public override void Perform(float value)
        {
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