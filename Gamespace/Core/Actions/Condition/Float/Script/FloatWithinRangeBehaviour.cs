using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class FloatWithinRangeBehaviour : FloatActionBehaviour
    {
        [SerializeField] private FloatActionVariable _minValue;
        [SerializeField] private FloatActionVariable _maxValue;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ _minValue, _maxValue };
        }
        public override void Perform(float value)
        {
            if (value > _minValue.value && value < _maxValue.value)
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