using System;
using System.Collections.Generic;
using Gamespace.Core.Player;
using Gamespace.UI;
using nanoid;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public abstract class VoidActionBehaviour : BaseActionBehavior
    {
        public abstract override void Perform();
        protected abstract override ActionVariable[] Variables();
        public override void Perform(int value)
        {
            Perform();
        }
        public override void Perform(float value)
        {
            Perform();
        }
        public override void Perform(string value)
        {
            Perform();
        }
        public abstract override Type[] GetAcceptingTypes();
    }
}