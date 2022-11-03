using System;
using System.Linq;
using System.Reflection;

namespace Gamespace.Core.Actions
{
    [Serializable]
    public abstract class ActionVariable
    {
        public FieldType fieldType;
        
        public virtual FieldInfo GetField()
        {
            return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public).First(field => !field.FieldType.IsEnum);
        }
    }
}