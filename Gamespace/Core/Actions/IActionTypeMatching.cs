using System;
using Gamespace.Core.ObjectMode;

namespace Gamespace.Core.Actions
{
    public interface IActionTypeMatching
    {
        IActionBehaviour[] GetMatchingType(IActionBehaviour[] behaviours, Type expectedType);
    }
}