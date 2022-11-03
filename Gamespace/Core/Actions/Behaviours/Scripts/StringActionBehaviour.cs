using System;
using System.Globalization;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public abstract class StringActionBehaviour : BaseActionBehavior
    {
        [Range(1, 10)]
        [SerializeField] private int _fixedPoints;

        protected abstract override ActionVariable[] Variables();
        public override void Perform()
        {
            Perform("");
        }
        public override void Perform(int value)
        {
            Perform(value.ToString());
        }
        public override void Perform(float value)
        {
            Perform(value.ToString($"F{_fixedPoints}"));
        }
        public abstract override void Perform(string value);
    }
}