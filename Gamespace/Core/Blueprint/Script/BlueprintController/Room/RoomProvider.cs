using Zenject;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


namespace Gamespace.Core.Blueprint.Room
{
    public class RoomProvider
    {
        public List<RoomBase> rooms => _rooms;

        [Inject] private SignalBus _signalBus;
        
        private List<RoomBase> _rooms = new List<RoomBase>();
        
        public void Add(RoomBase newObject)
        {
            newObject.Initialize();
            var room = HandleDuplicateId(newObject);
            _rooms.Add(room);
        }
        public void Remove(RoomBase objectToRemove)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].id != objectToRemove.id)
                    continue;

                _rooms[i].Dispose();
                _rooms.RemoveAt(i);
            }
            
            _signalBus.Fire(new RoomDisposeResponseSignal());
        }
        public void Remove()
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                _rooms[i].Dispose();
            }
            
            _rooms.Clear();
            _signalBus.Fire(new RoomDisposeResponseSignal());
        }
        public void OnRoomInitialized(RoomInitializeSignal signal)
        {
            Add(signal.room);
        }
        public void OnRoomDeinitialized(RoomDisposeRequestSignal requestSignal)
        {
            if (requestSignal.room is null)
            {
                Remove();
                return;
            }
            
            Remove(requestSignal.room);
        }
        public void OnRoomRequested(RoomRequestSignal signal)
        {
            List<RoomBase> matches;
            RoomBase[] total;

            if (string.IsNullOrEmpty(signal.specifier))
            {
                total = _rooms.ToArray();
                _signalBus.Fire(new RoomResponseSignal(signal.requestId, total));
                return;
            }
            
            matches = _rooms.FindAll(room => signal.specifier.ToLower().Contains(room.id.ToLower()));
            total = matches.Concat(_rooms.FindAll(placeable => placeable.id == signal.specifier)).ToArray();
            _signalBus.Fire(new RoomResponseSignal(signal.requestId, total));
        }
        private RoomBase HandleDuplicateId(RoomBase duplicatedObject)
        {
            var room = duplicatedObject;
            if (_rooms.Exists(o => o.id == duplicatedObject.id))
            {
                room.Initialize();
                room = HandleDuplicateId(duplicatedObject);
            }

            return room;
        }
    }

    public class RoomInitializeSignal
    {
        public RoomBase room => _room;
        private RoomBase _room;
        
        public RoomInitializeSignal(RoomBase room)
        {
            _room = room;
        }
    }
    public class RoomDisposeRequestSignal
    {
        public RoomBase room => _room;
        private RoomBase _room;
        
        public RoomDisposeRequestSignal()
        {
            _room = null;
        }
        public RoomDisposeRequestSignal(RoomBase room)
        {
            _room = room;
        }
    }

    public class RoomDisposeResponseSignal
    {
        
    }
}