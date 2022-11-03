using System;
using UnityEngine;
using System.Collections.Generic;

namespace Gamespace.Core.Actions
{
    public class SetDisableBehaviour : VoidActionBehaviour
    {
        [SerializeField] private GameObject _target;
        public override void Perform()
        {
            _target.SetActive(false);
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
            _objectName = $"{objectName}'s Set disable.";
        }
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
        }
    }
}