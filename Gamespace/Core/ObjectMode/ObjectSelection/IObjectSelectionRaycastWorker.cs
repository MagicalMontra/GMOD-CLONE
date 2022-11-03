using UnityEngine;

namespace Gamespace.Core.ObjectMode.Selection
{
    public interface IObjectSelectionRaycastWorker
    {
        Ray Cast();
    }
}