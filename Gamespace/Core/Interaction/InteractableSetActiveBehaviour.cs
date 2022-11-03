using System;
using System.Collections.Generic;
using Gamespace.Core.Actions;
using Gamespace.Utilis;
using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public class InteractableSetActiveBehaviour : VoidActionBehaviour
    {
        [TypeConstraint(typeof(IInteractable))]
        [SerializeField] private GameObject _target;
        private IInteractable _interactable;
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
        }
        public override void Perform()
        {
            _interactable.SetActive(true);
            Next();
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