using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Blueprint.Room
{
    public class RoomRotateWorker : IInitializable, ILateDisposable
    {
        [Inject] private RoomController _roomController;
        [Inject] private RoomRotateInputWorker _roomRotateInputWorker;
        
        private void RotateRoom()
        {
            if (_roomController.currentRoom)
            {
                _roomController.currentRoom.FilpRotationRoom();
            }
        }
        public void Initialize()
        {
            _roomRotateInputWorker.Initialize(RotateRoom);
        }

        public void LateDispose()
        {
            _roomRotateInputWorker.Dispose();
        }
    }

}
