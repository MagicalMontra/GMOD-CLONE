using Gamespace.Core.Blueprint.Room;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomMovementWorker
    {
        [Inject] private BlurprintCameraSettings _cameraSettings;
        [Inject] private RoomSettings _settings;
        [Inject] private FloorSliderWorker _floorWorker;

        public void MoveRoom(RoomBase targetRoom)
        {
            if (targetRoom is null)
                return;

            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition.z = _cameraSettings.mainCamera.transform.position.y;
            var relativePosition = _cameraSettings.mainCamera.ScreenToWorldPoint(mousePosition);

            if (!targetRoom.GetSnapping())
            {
                var position = relativePosition;
                position.y += _floorWorker.currentFloor * _settings.floorHeightMultiplier; // Floor height
                targetRoom.transform.position = position;
            }

            targetRoom.SetMousePosition(relativePosition);

            // if (targetRoom != null)
            //     if (Input.GetKeyUp(KeyCode.Q))
            //     {
            //         roomBase.FilpRotationRoom();
            //     }
            //     if (Input.GetKeyUp(KeyCode.B) || Input.GetKeyUp(KeyCode.Escape))
            //     {
            //         RoomBase room = roomBase;
            //         roomBase.OnDeselected();
            //         blueprintController.RemoveRoom(room);
            //         GameObject.Destroy(room.gameObject);
            //         targetRoom = null;
            //     }
            // }


            //        var mousePos = Input.mousePosition;
            //        mousePos.z = bluePirntCamera.transform.position.y; // select distance = 10 units from the camera
            //        Vector3 mPos = _mainCamera.ScreenToWorldPoint(mousePos);

            //        if (!roomBase.GetSnapping())
            //        {
            //            Vector3 v = mPos;
            //            v.y += blueprintController.GetFloorSlider().GetCurrentFloor() * 7;
            //            targetRoom.transform.position = v;
            //        }

            // if (Input.GetMouseButtonUp(0))
            // {

            //     if (roomBase.CheckRoomOverlap())
            //     {
            //         return;
            //     }

            //     roomBase.OnDeselected();
            //     targetRoom = null;
            // }
        }
        public void OnDeselectRoom()
        {
            // if (targetRoom == null)
            // {
            //     return;
            // }
            // Vector3 v = this.transform.position;
            // v.y = 0;
            // v.y += _floorWorker.GetCurrentFloor() * 7;// Floor height
            // targetRoom.transform.position = v;

            // blueprintController.SetRoomHint(false);
            // targetRoom.OnDeselected();
            // targetRoom = null;

        }
        public void TeleportPlayerToSelectedRoom()
        {
            // if (targetRoom == null)
            // {
            //     return;
            // }
            // Vector3 teleportPos = targetRoom.transform.position;
            // teleportPos.y = targetRoom.transform.position.y;
            // blueprintController.switchObjectMode.TeleportPlayer(teleportPos);
            // targetRoom.OnDeselected();
        }
    }

}
