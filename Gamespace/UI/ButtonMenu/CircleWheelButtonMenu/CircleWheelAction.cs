using System;

namespace Gamespace.UI
{
    public class CircleWheelAction
    {
        public string id;
        public string desc;
        public Action action;
        
        public CircleWheelAction(string id, Action action)
        {
            this.id = id;
            this.action = action;
        }

        public CircleWheelAction(string id, string desc, Action action)
        {
            this.id = id;
            this.desc = desc;
            this.action = action;
        }
    }
}