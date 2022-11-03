using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomRemoveWorker : IInitializable, ILateDisposable
    {
        [Inject] private RoomRemoveInputWorker _roomRemoveInputWorker;
        [Inject] private RoomController _roomController;
        
        void IInitializable.Initialize()
        {
            _roomRemoveInputWorker.Initialize(RemoveRoom);
        }

        void ILateDisposable.LateDispose()
        {
            _roomRemoveInputWorker.Dispose();
        }

       public void RemoveRoom()
        {
            if (_roomController.currentRoom)
            {
                RoomBase roomBase_ = _roomController.currentRoom;
                roomBase_.OnDeselected();
                GameObject.Destroy(roomBase_.gameObject);
                _roomController.SetCurrentRoom(null);
            }
        }
    }

}
