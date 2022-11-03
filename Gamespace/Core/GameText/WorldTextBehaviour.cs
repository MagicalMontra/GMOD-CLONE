using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class WorldTextBehaviour : StringActionBehaviour
    {
        [SerializeField] private TextMeshPro _textMesh;
        [SerializeField] private StringActionVariable defaultValue;
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ defaultValue };
        }
        public override void Perform(string value)
        {
            if (string.IsNullOrEmpty(value))
                value = defaultValue.value;
            
            _textMesh.text = value;
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