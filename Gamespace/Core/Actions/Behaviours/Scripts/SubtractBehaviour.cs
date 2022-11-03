using System.Collections.Generic;
using System;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class SubtractBehaviour : FloatActionBehaviour
    {
        [SerializeField] private FloatActionVariable _subtractValue;
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
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[] { _subtractValue };
        }
        public override void Perform(float value)
        {
            value -= _subtractValue.value;
            Next(value);
        }
    }

}
