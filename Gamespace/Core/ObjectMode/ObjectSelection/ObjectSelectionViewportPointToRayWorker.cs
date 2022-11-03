using Gamespace.Utilis;
using Zenject;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionViewportPointToRayWorker : IObjectSelectionRaycastWorker
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ObjectSelectionSettings _settings;
        
        public Ray Cast()
        {
            Ray ray = _settings.mainCamera.ViewportPointToRay(Vector3.one * 0.5f);
            _signalBus.Fire(new GizmoRequestSignal(() => Gizmos.DrawLine(ray.origin, ray.direction * 5f + ray.origin)));
            return ray;
        }
    }
}