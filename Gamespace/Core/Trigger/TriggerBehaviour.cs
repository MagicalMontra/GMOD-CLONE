using System;
using System.Collections.Generic;
using Gamespace.Core.Actions;

namespace Gamespace.Core.Trigger
{
    public class TriggerBehaviour : VoidActionBehaviour
    {
        public override void Perform()
        {
            Next();
        }
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
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