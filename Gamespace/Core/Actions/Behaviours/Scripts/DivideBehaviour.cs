using System.Collections.Generic;
using System;
namespace Gamespace.Core.Actions
{
    public class DivideBehaviour : FloatActionBehaviour
    {
        public FloatActionVariable divideValue;
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
            return new ActionVariable[]{ divideValue };
        }
        public override void Perform(float value)
        {
            if(divideValue.value == 0)
            {
                divideValue.value = 1;
            }
            
            value /= divideValue.value;
            Next(value);
        }
    }

}
