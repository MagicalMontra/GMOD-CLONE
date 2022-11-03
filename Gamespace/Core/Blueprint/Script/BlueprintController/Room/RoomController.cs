using Zenject;
using UnityEngine;
using Gamespace.Core.GameStage;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomController : IInitializable, ITickable, ILateDisposable
    {
        public RoomBase currentRoom => _currentRoom;
        
        [Inject] private SignalBus _signalBus;
        [Inject] private IRoomSelector _roomSelector;
        [Inject] private RoomMovementWorker _roomMoveWorker;
        [Inject] private BlueprintHintWorker _blueprintHintWorker;
        [Inject] private RoomBuildPanelWorker _bluepirntRoomPanel;
        [Inject] private RoomSelectionInputWorker _selectionInputWorker;

        private bool _isBlueprintMode;
        private bool _isPause;
        private RoomBase _currentRoom;

      
        public void Initialize()
        {
            _selectionInputWorker.Initialize(Select);
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
            _signalBus.Subscribe<PauseRequestSignal>(PauseChecker);
        }
        public void LateDispose()
        {
            _selectionInputWorker.Dispose();
        }
        public void Tick()
        {
            _roomMoveWorker.MoveRoom(_currentRoom);
           // _roomMoveWorker.MoveRoom(new Vector3(_moveInputWorker.deltaPosition.x, 0 , _moveInputWorker.deltaPosition.y), _currentRoom);
        }
        private void Select(Vector2 mousePosition)
        {
            if(_isPause)
                return;

            if(_isBlueprintMode)
            {
                return;
            }

            if(_bluepirntRoomPanel.CheckIsPanelOpen())
            {
                return;
            }

            
            if (_currentRoom)
            {
                if (_currentRoom.isOverlap)
                    return;

                _currentRoom.OnDeselected();
                _currentRoom = null;
                _blueprintHintWorker.EnableSelectedHint(_currentRoom);
                return;
            }
            
            _currentRoom = _roomSelector.Select(mousePosition);
            if (_currentRoom)
                _currentRoom.OnSelected();

            _blueprintHintWorker.EnableSelectedHint(_currentRoom);

        }
        public void SetCurrentRoom(RoomBase room = null)
        {
            _currentRoom = room;
            if(room != null)
                room.OnSelected();
        }
        public void PauseChecker(PauseRequestSignal signal)
        {
            _isPause = signal.isPause;

            if(_isPause)
            {
                  if (_currentRoom)
                {
                    _currentRoom.OnDeselected();
                    _currentRoom = null;
                    _blueprintHintWorker.EnableSelectedHint(_currentRoom);
                    return;
                }
            }
        }
        private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object||signal.gameStage == Stage.Play)
            {
                if(_currentRoom)
                {
                _currentRoom.OnDeselected();
                _currentRoom = null;
                }

                _isBlueprintMode =true;
                return;
            }
            _isBlueprintMode =false;
        }
    }

}
