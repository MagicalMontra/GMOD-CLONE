using System;
using System.Collections.Generic;

namespace Gamespace.Core.Actions
{
    public class ActionInterfaceTypeMatching : IActionTypeMatching
    {
        public IActionBehaviour[] GetMatchingType(IActionBehaviour[] behaviours, Type expectedType)
        {
            List<IActionBehaviour> matchedBehaviour = new List<IActionBehaviour>();
            object filterCriteria = expectedType.ToString();

            for (int i = 0; i < behaviours.Length; i++)
            {
                if (behaviours[i].GetType().FindInterfaces(InterfaceFilter, filterCriteria).Length > 0)
                    matchedBehaviour.Add(behaviours[i]);
            }

            return matchedBehaviour.ToArray();
        }
        private bool InterfaceFilter(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
}