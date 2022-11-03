using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class FloatMoreThanBehaviour : FloatActionBehaviour
    {
        [SerializeField] private FloatActionVariable _threshold;
        [SerializeField] private BoolActionVariable _countEqual;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ _threshold, _countEqual };
        }
        public override void Perform(float value)
        {
            if (_countEqual.value)
            {
                if (value >= _threshold.value)
                    Next(value);
                
                return;
            }
            
            if (value > _threshold.value)
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