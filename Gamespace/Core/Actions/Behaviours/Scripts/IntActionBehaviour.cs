using Gamespace.Core.Player;
using Gamespace.UI;
using nanoid;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public abstract class IntActionBehaviour : BaseActionBehavior
    {
        protected abstract override ActionVariable[] Variables();
        public override void Perform()
        {
            Perform(0);
        }
        public override void Perform(float value)
        {
            var integer = Mathf.CeilToInt(value);
            Perform(integer);
        }
        public abstract override void Perform(int value);
        public override void Perform(string value)
        {
            int.TryParse(value, out var outValue);
            Perform(outValue);
        }
    }
}