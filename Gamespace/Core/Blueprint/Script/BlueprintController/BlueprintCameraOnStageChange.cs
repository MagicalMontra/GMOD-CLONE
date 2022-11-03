using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.Blueprint.Room;
using UnityEngine;
using Gamespace.Core.GameStage;
using Zenject;
using Gamespace.Core.Player;

namespace Gamespace.Core.Blueprint
{
    public class BlueprintCameraOnStageChange :IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private RoomProvider _provider;
        [Inject] private FloorSliderWorker _floorSliderWorker;
        [Inject] private BlueprintHintWorker _blueprintHintWorker;
        [Inject] private RoomBuildPanelWorker roomBuildPanelWorker;
        [Inject] private BlurprintCameraSettings _blueprintCameraSetting;

        private bool _isLocked;

        public void Initialize()
        {
              _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }

        private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play || signal.gameStage == Stage.Object)
            {
                EnableHintInterface(false);
                for(int i = 0; i < _provider.rooms.Count; i++)
                    _provider.rooms[i].materialSwapper.SetOriginalMaterial();
                
                if (!_isLocked) 
                    return;
                
                _signalBus.AbstractFire(new PlayerUnlockSignal("Blueprint"));
                roomBuildPanelWorker.ActiveRoomPanel(false);
                _isLocked = false;

                return;
            }

            EnableHintInterface(true);
            for(int i = 0; i < _provider.rooms.Count; i++)
                _provider.rooms[i].materialSwapper.SetActive(0);

            if (_isLocked) 
                return;
            
            _signalBus.AbstractFire(new PlayerLockSignal("Blueprint"));
            _isLocked = true;

        }

        private void EnableHintInterface(bool isEnable)
        {
            _blueprintCameraSetting.bluePrintCamera.gameObject.SetActive(isEnable);
            _blueprintCameraSetting.bluePrintCameraOverlay.gameObject.SetActive(isEnable);
            _blueprintHintWorker.EnableHintGameObject(isEnable);
            _floorSliderWorker.EnableFloorGameobject(isEnable);
        }
    }

}