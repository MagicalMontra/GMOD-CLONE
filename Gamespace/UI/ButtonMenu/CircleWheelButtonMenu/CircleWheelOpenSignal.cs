using System;
using System.Collections.Generic;

namespace Gamespace.UI
{
    public class CircleWheelOpenSignal : ICircleWheelOpenSignal
    {
        public Action closeAction => _closeAction;
        public CircleWheelAction[] actions => _actions;
        private CircleWheelAction[] _actions;
        private Action _closeAction;
        
        public CircleWheelOpenSignal(Action closeAction, params CircleWheelAction[] actions)
        {
            _actions = actions;
            _closeAction = closeAction;
        }
    }

    public class CircleWheelCloseSignal : ICircleWheelCloseRequest
    {
        
    }
}