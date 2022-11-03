using System;
using System.Collections.Generic;

namespace Gamespace.Core.Actions
{
    public class ActionAbstractTypeMatching : IActionTypeMatching
    {
        public IActionBehaviour[] GetMatchingType(IActionBehaviour[] behaviours, Type expectedType)
        {
            List<IActionBehaviour> matchedBehaviour = new List<IActionBehaviour>();

            for (int i = 0; i < behaviours.Length; i++)
            {
                if (behaviours[i].GetType().IsSubclassOf(expectedType))
                    matchedBehaviour.Add(behaviours[i]);
            }

            return matchedBehaviour.ToArray();
        }
    }
}