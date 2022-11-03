using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Rotation;
using Gamespace.Core.ObjectMode.Elevation;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPlacingWorker : IInitializable, ITickable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IObjectPlacingPointer _pointer;
        [Inject] private ObjectProvider _objectProvider;
        [Inject] private ObjectPlacingHintSettings _hintSettings;
        [Inject] private ObjectDistanceWorker _objectDistanceWorker;
        [Inject] private PlacingPositionValidator _positionValidator;
        [Inject] private ObjectPlaceInputWorker _objectPlaceInputWorker;
        [Inject] private IPlaceableObject.Factory _placeableObjectFactory;
        [Inject] private PlacingSurfaceMatchingWorker _surfaceMatchingWorker;
        [Inject] private ObjectPlaceExitInputWorker _objectPlaceExitInputWorker;

        private float _yRotate;
        private bool _isEnabled;
        private bool _createMode;
        private bool _isIntersect;
        private bool _neededRotate;
        private GameObject _sourceObject;
        private PlacingData _placingData;
        private IPlaceableSurface[] _surfaces;
        private IPlaceableObject _candidateObject;
        
        private void Dispose()
        {
            _isEnabled = false;
            _candidateObject = null;
        }
        private async void PlaceCandidate()
        {
            if (!_isEnabled)
                return;

            if (_candidateObject is null)
                return;
            
            if (!_placingData.isEnabled)
                return;

            if (_isIntersect)
                return;
            
            _isEnabled = false;
            _candidateObject.placingMaterialSwapper.SetOriginalMaterial();
            
            if (_positionValidator.selectedSurfaceIndex > -1)
                _candidateObject.SetParent(_surfaces[_positionValidator.selectedSurfaceIndex]);

            if (_createMode)
            {
                _objectProvider.Add(_candidateObject);
                Place(_placeableObjectFactory.Create(_sourceObject));
                _candidateObject.OnCreateCandidate();
            }
            else
            {
                _isEnabled = false;
                _pointer.SetDisable();
                _hintSettings.controlHintPanel.SetActive(false);

                await Task.Delay(250);
                _signalBus.AbstractFire(new PlacingExitResponseSignal());
                _signalBus.AbstractFire(new PlaceableRotateExitRequestSignal());
                _signalBus.AbstractFire(new ObjectElevationExitRequestSignal());
            }
        }
        public void OnPlaceableUIOpened(IPlaceablePanelOpenSignal signal)
        {
            if (!_isEnabled)
                return;
            
            if (!_createMode)
                return;

            _isEnabled = false;
            _pointer.SetDisable();
            _hintSettings.controlHintPanel.SetActive(false);
            Object.Destroy(_candidateObject.gameObject);
        }
        private void Exit(InputAction.CallbackContext context)
        {
            if (!_isEnabled)
                return;

            _isEnabled = false;
            _pointer.SetDisable();
            _hintSettings.controlHintPanel.SetActive(false);

            if (_createMode)
                Object.Destroy(_candidateObject.gameObject);
            
            
            _candidateObject = null;
            _signalBus.AbstractFire(new PlacingExitResponseSignal());
            _signalBus.AbstractFire(new PlaceableRotateExitRequestSignal());
            _signalBus.AbstractFire(new ObjectElevationExitRequestSignal());
        }
        private void Place(IPlaceableObject placeable)
        {
            _candidateObject = placeable;
            _candidateObject.SetParent(null);
            _signalBus.AbstractFire(new ObjectElevationRequestSignal(_candidateObject));
            _signalBus.AbstractFire(new PlaceableRotateRequestSignal(_candidateObject));
            _isEnabled = true;
        }
        public void OnNewPlacingRequest(INewPlacingRequestSignal signal)
        {
            _createMode = true;
            _sourceObject = signal.data.prefab;
            _hintSettings.controlHintPanel.SetActive(true);
            Place(_placeableObjectFactory.Create(_sourceObject));
            _candidateObject.OnCreateCandidate();
        }
        public void OnPlacingRequest(IPlacingRequestSignal signal)
        {
            _createMode = false;
            _hintSettings.controlHintPanel.SetActive(true);
            Place(signal.placeable);
        }
        public void OnPlaceableSurfaceResponse(PlaceableSurfaceResponseSignal signal)
        {
            if (signal.id != "PlacingObject")
                return;

            _surfaces = signal.surfaces.ToArray();
        }
        public void Tick()
        {
            if (!_isEnabled)
                return;

            _placingData = _positionValidator.Validate(_surfaces);
            _candidateObject.SetSpawnCandidatePosition(_placingData);

            var objects = _objectDistanceWorker.GetInDistanceObjects(12f);
            for (int i = 0; i < objects.Count; i++)
            {
                if (_candidateObject.id == objects[i].id)
                    continue;

                var distance = 0f;
                var direction = Vector3.zero;
                if (Physics.ComputePenetration(_candidateObject.collider,
                    _candidateObject.position, _candidateObject.rotation,
                    objects[i].collider, objects[i].position,
                    objects[i].rotation, out direction, out distance))
                {
                    _isIntersect = true;
                    _placingData.Set(false, _placingData.position);
                    break;
                }

                _isIntersect = false;
            }

            for (int i = 0; i < _surfaces.Length; i++)
            {
                if (_positionValidator.selectedSurfaceIndex == i)
                    continue;
                
                var distance = 0f;
                var direction = Vector3.zero;
                
                if (Physics.ComputePenetration(_candidateObject.collider,
                    _candidateObject.position, _candidateObject.rotation,
                    _surfaces[i].collider, _surfaces[i].transform.position,
                    _surfaces[i].transform.rotation, out direction, out distance))
                {
                    _isIntersect = true;
                    _placingData.Set(false, _placingData.position);
                    break;
                }

                _isIntersect = false;
            }
            
            if (_positionValidator.selectedSurfaceIndex > -1)
                _placingData.Set(_placingData.isEnabled && _surfaceMatchingWorker.MatchSurface(_candidateObject, _surfaces[_positionValidator.selectedSurfaceIndex]), _placingData.position);

            _pointer.SetPointer(_placingData);
            _candidateObject.placingMaterialSwapper.SetActive(!_isIntersect && _placingData.isEnabled);
        }
        public void LateDispose()
        {
            Dispose();
            _objectPlaceInputWorker.Dispose();
            _objectPlaceExitInputWorker.Dispose();
        }
        public void Initialize()
        {
            _objectPlaceInputWorker.Initialize(PlaceCandidate);
            _objectPlaceExitInputWorker.Initialize(Exit);
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object)
                return;

            _isEnabled = false;
            _pointer.SetDisable();
            _hintSettings.controlHintPanel.SetActive(false);
            _signalBus.AbstractFire(new PlacingExitResponseSignal());
        }
    }
}