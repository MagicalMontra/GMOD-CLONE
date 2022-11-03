using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace Gamespace.Core.Actions
{
    public class AdditionBehaviour : FloatActionBehaviour
    {
        public FloatActionVariable additionValue;
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
            return new ActionVariable[]{ additionValue };
        }
        public override void Perform(float value)
        {
            value = value + additionValue.value;
            Next(value);
        }
    }

}
