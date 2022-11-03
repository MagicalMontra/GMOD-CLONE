using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gamespace.Core.GameStage;
using Gamespace.Core.Save;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomBuildPanelWorker : IInitializable,ILateDisposable
    {   
        [Inject] private SignalBus _signalBus;
        [Inject] private RoomProvider _provider;
        [Inject] private RoomBuildPanelSetting _roomBuildPanelsetting;
        [Inject] private RoomBuildPanelInputWorker _roomBuildPanelInputWorker;

        [Inject] private RoomButtonConsumer.Factory _roomButtonFactory;
        [Inject] private RoomBase.Factory _roomFactory;

        [Inject] private RoomController _roomController;
        private bool _isPause;
        private bool _isOpenPanel;
        
        public void Initialize()
        {
            _roomBuildPanelInputWorker.Initialize(EnableRoomPanel);
            _signalBus.Subscribe<PauseRequestSignal>(OnPauseRequestSignal);
            CrateRoomButtons(_roomBuildPanelsetting.roomInfo.roomDetails);
        }
       
        public void LateDispose()
        {
            _roomBuildPanelInputWorker.Dispose();
        }
        public void EnableRoomPanel()
        {
            if(_isPause)
                return;
            if(_roomController.currentRoom)
                return;

            ActiveRoomPanel(!_roomBuildPanelsetting.blueprintPanelGameObject.activeInHierarchy);
        }
    
        private void CrateRoomButtons(RoomDetail[] roomDetails)
        {
             for (int i = 0; i < roomDetails.Length; i++)
            {
                RoomButtonConsumer roomButton = _roomButtonFactory.Create();
                roomButton.SetUp(i,roomDetails[i].roomIcon,_roomBuildPanelsetting.blueprintPanelContent);
            }
        }
        public void CreateStartRoom(int index)
        {
            var room = _roomFactory.Create(_roomBuildPanelsetting.roomInfo.roomDetails[index].roomPrefab);
            Vector3 startPosition = new Vector3(0, 0, 0);
            room.transform.position = startPosition;
            _provider.Add(room);
            ActiveRoomPanel(false);
        }
        public void CreateRoomFromPrefab(int index)
        {       
            var room = _roomFactory.Create(_roomBuildPanelsetting.roomInfo.roomDetails[index].roomPrefab);
            Vector3 startPosition = new Vector3(0, 0, 0);
            
            room.transform.position = startPosition;
            _provider.Add(room);
            _roomController.SetCurrentRoom(room);
            ActiveRoomPanel(false);
        }

      public bool CheckIsPanelOpen()
      {
          return _roomBuildPanelsetting.blueprintPanelGameObject.activeInHierarchy;;
      }

      public void ActiveRoomPanel(bool isActive)
      {
          _roomBuildPanelsetting.blueprintPanelGameObject.SetActive(isActive);
      }

        public void OnPauseRequestSignal(PauseRequestSignal signal)
        {
            _isPause = signal.isPause;

            if(_isPause)
                ActiveRoomPanel(false);
 
        }
    }

}
