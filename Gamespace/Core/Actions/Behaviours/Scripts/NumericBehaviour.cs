using System.Collections.Generic;
using System;
namespace Gamespace.Core.Actions
{
    public class NumericBehaviour : FloatActionBehaviour
    {
        public FloatActionVariable numericValue;
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
            return new ActionVariable[]{ numericValue };
        }
        public override void Perform(float value)
        {
            value = numericValue.value;
            Next(value);
        }
    }

}
