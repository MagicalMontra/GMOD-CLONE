using System.Collections.Generic;
using System;
namespace Gamespace.Core.Actions
{
    public class MultiplyBehaviour : FloatActionBehaviour
    {
        public FloatActionVariable multiplyValue; 
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
            return new ActionVariable[]{ multiplyValue };
        }
        public override void Perform(float value)
        {
            value *= multiplyValue.value;
            Next(value);
        }
    }

}
