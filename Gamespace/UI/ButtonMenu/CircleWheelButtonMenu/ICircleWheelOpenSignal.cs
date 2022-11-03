using System;
using System.Collections.Generic;

namespace Gamespace.UI
{
    public interface ICircleWheelOpenSignal
    {
        Action closeAction { get; }
        CircleWheelAction[] actions { get; }
    }

    public interface ICircleWheelCloseRequest
    {
        
    }
}