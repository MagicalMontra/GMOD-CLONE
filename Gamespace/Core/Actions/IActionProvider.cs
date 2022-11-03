using System.Collections.Generic;
using Gamespace.Core.ObjectMode;

namespace Gamespace.Core.Actions
{
    public interface IActionProvider
    {
        void OnActionInitialized(ActionInitializeSignal signal);
        void GetLinkedAction(FindLinkedActionSignal signal);
    }
}