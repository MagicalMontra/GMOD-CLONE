using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class FloatNotEqualBehaviour : FloatActionBehaviour
    {
        [SerializeField] private FloatActionVariable _threshold;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ _threshold };
        }
        public override void Perform(float value)
        {
            if (!Mathf.Approximately(value, _threshold.value))
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