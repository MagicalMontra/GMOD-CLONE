using Zenject;
using UnityEngine;
using Gamespace.Utilis;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomMouseRaycastSelector : IRoomSelector
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BlurprintCameraSettings _settings;
        public RoomBase Select(Vector2 selectPosition)
        {
            RaycastHit hit;
            RoomBase room = null;
            var ray = _settings.mainCamera.ScreenPointToRay(selectPosition);
            _signalBus.Fire(new GizmoRequestSignal(() => 
            {
                Gizmos.DrawLine(ray.origin, ray.direction * 100f + ray.origin);
            }));

            if (Physics.Raycast(ray, out hit))
                room = hit.transform.GetComponent<RoomBase>();

            return room;
        }
    }

}
