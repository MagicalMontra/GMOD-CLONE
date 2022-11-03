using System;

namespace Gamespace.Utilis
{
    public class GizmoRequestSignal
    {
        public Action gizmoAction => _gizmoAction;
        private Action _gizmoAction;

        public GizmoRequestSignal(Action gizmoAction)
        {
            _gizmoAction = gizmoAction;
        }
    }
}