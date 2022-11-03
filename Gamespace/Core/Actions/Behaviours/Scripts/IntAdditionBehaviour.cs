using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class IntAdditionBehaviour : IntActionBehaviour
    {
        [SerializeField] private IntActionVariable _additionValue;

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
            return new ActionVariable[]{ _additionValue };
        }
        public override void Perform(int value)
        {
            var result = value + _additionValue.value;
            Next(result);
        }
    }
}