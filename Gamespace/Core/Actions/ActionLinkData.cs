using System;

namespace Gamespace.Core.Actions
{
    [Serializable]
    public class ActionLinkData
    {
        public string linkedBehaviourId;
        public ActionLinkRenderer linkRenderer;
        public IActionBehaviour linkedBehaviour;
    }
}