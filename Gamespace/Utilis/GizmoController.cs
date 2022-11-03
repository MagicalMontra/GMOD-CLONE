using Zenject;

namespace Gamespace.Utilis
{
    public class GizmoController : IInitializable
    {
        [Inject] private NonMonoDrawGizmo.Factory _factory;

        private NonMonoDrawGizmo _gizmoHandler;
        
        public void Initialize()
        {
            _gizmoHandler = _factory.Create();
        }
        public void OnGizmoRequest(GizmoRequestSignal signal)
        {
            _gizmoHandler.drawGizmo = signal.gizmoAction;
        }
    }
}