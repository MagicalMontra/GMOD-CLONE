using System;
using System.Collections.Generic;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Elevation;
using Gamespace.Core.ObjectMode.Rotation;
using Gamespace.Core.Player;
using Gamespace.UI;
using Zenject;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionWorker : IInitializable, ITickable, ILateDisposable, IOnGameStageChange
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ObjectSelectionSettings _settings;
        [Inject] private ObjectDistanceWorker _objectDistanceWorker;
        [Inject] private IObjectSelectionWorker _objectSelectionWorker;
        [Inject] private ObjectSelectionEnableStack _objectSelectionEnableStack;
        [Inject] private ObjectSelectionOpenPanelInputWorker _openPanelInputWorker;
        [Inject] private IObjectSelectionRaycastWorker _objectSelectionRaycastWorker;

        private bool _isCorrectMode;
        private int _objectIndex = -1;
        private int _previousObjectIndex = -1;
        private List<IPlaceableObject> _placeableObjects;
        private List<CircleWheelAction> _wheelPanelActions = new List<CircleWheelAction>();

        public void Tick()
        {
            if (!_isCorrectMode)
                return;

            if (!_objectSelectionEnableStack.isEnabled)
            {
                if (_settings.indicatorPanel.activeInHierarchy)
                    _settings.indicatorPanel.SetActive(false);

                return;
            }

            _placeableObjects = _objectDistanceWorker.GetInDistanceObjects(12f);
            
            if (_placeableObjects.Count <= 0)
                return;

            _objectIndex = _objectSelectionWorker.Select(_placeableObjects, _objectSelectionRaycastWorker.Cast());
            
            if (_placeableObjects.Count - 1 < _objectIndex)
                return;
            
            if (_placeableObjects.Count - 1 < _previousObjectIndex)
                return;

            if (_objectIndex > -1)
            {
                if (_previousObjectIndex > -1 && _previousObjectIndex != _objectIndex)
                    _placeableObjects[_previousObjectIndex].placingMaterialSwapper.SetOriginalMaterial();

                _previousObjectIndex = _objectIndex;
                _settings.indicatorPanel.SetActive(true);
                _placeableObjects[_objectIndex].placingMaterialSwapper.SetActive(true);
            }
            else
            {
                if (_previousObjectIndex < 0)
                    return;
                
                _settings.indicatorPanel.SetActive(false);
                _placeableObjects[_previousObjectIndex].placingMaterialSwapper.SetOriginalMaterial();
                _previousObjectIndex = -1;
            }
        }
        private void OpenWheel()
        {
            if (!_isCorrectMode)
                return;

            if (!_objectSelectionEnableStack.isEnabled)
                return;

            if (_objectIndex < 0)
                return;

            for (int i = 0; i < _placeableObjects.Count; i++)
                _placeableObjects[i].placingMaterialSwapper.SetOriginalMaterial();

            var currentWheelActions = new List<CircleWheelAction>();

            currentWheelActions.ForEach(action => currentWheelActions.Add(action));

            for (int i = 0; i < _wheelPanelActions.Count; i++)
                currentWheelActions.Add(_wheelPanelActions[i]);

            for (int i = 0; i < _placeableObjects[_objectIndex].actionBehaviours.Length; i++)
            {
                var wheelAction = _placeableObjects[_objectIndex].actionBehaviours[i].GetWheelAction();
                currentWheelActions.Add(wheelAction);
            }

            _signalBus.AbstractFire(new CircleWheelOpenSignal(() =>
            {
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
            }, currentWheelActions.ToArray()));

            _signalBus.AbstractFire(new ObjectSelectionDisableSignal("Object Properties Wheel"));
            _signalBus.AbstractFire(new PlayerLockSignal("Object Properties Wheel"));

            _settings.indicatorPanel.SetActive(_objectSelectionEnableStack.isEnabled);
        }
        public void Initialize()
        {
            _placeableObjects = new List<IPlaceableObject>();
            _openPanelInputWorker.Initialize(OpenWheel);
            _wheelPanelActions.Add(new CircleWheelAction(_settings.panelButtonIds[0], () =>
            {
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new PlaceableRotateRequestSignal(_placeableObjects[_objectIndex]));
            }));
            _wheelPanelActions.Add(new CircleWheelAction(_settings.panelButtonIds[1], () =>
             {
                 _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                 _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                 _signalBus.AbstractFire(new ObjectElevationRequestSignal(_placeableObjects[_objectIndex]));
             }));
            _wheelPanelActions.Add(new CircleWheelAction(_settings.panelButtonIds[2], () =>
            {
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new SelectedObjectPlacingRequest(_placeableObjects[_objectIndex]));
            }));
        }
        public void LateDispose()
        {
            _openPanelInputWorker.Dispose();
            _wheelPanelActions.Clear();
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            _isCorrectMode = signal.gameStage == Stage.Object;

            if (!_isCorrectMode)
            {
                _settings.indicatorPanel.SetActive(false);
                
                for (int i = 0; i < _placeableObjects.Count; i++)
                    _placeableObjects[i].placingMaterialSwapper.SetOriginalMaterial();
            }
        }
    }
}
