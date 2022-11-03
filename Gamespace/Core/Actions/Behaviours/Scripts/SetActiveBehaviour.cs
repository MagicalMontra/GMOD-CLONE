using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class SetActiveBehaviour : VoidActionBehaviour
    {
        [SerializeField] private GameObject _target;
        public override void Perform()
        {
            _target.SetActive(true);
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
        public override void OnInitialized(string objectId, string objectName)
        {
            base.OnInitialized(objectId, objectName);
            _objectName = $"{objectName}'s Set active.";
        }
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
        }
    }
}