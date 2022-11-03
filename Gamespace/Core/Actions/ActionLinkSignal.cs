using System;
using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.Actions
{
    public class ActionLinkSignal
    {
        public string relinkId => _relinkId;
        public string excludeId => _excludeId;
        public ActionLinkRenderer linkRenderer => _linkRenderer;
        public IActionBehaviour behaviour => _behaviour;
        private string _relinkId;
        private string _excludeId;
        private ActionLinkRenderer _linkRenderer;
        private IActionBehaviour _behaviour;

        public ActionLinkSignal(string excludeId, IActionBehaviour behaviour)
        {
            _excludeId = excludeId;
            _behaviour = behaviour;
        }
        public ActionLinkSignal(string relinkId, string excludeId, IActionBehaviour behaviour, ActionLinkRenderer linkRenderer = null)
        {
            _relinkId = relinkId;
            _excludeId = excludeId;
            _linkRenderer = linkRenderer;
            _behaviour = behaviour;
        }
    }
}