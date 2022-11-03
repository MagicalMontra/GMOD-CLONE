using nanoid;
using Zenject;
using UnityEngine;
using Gamespace.Core.Actions;
using System.Collections.Generic;
using System.Security.Cryptography;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.Serialization;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.Serialization;

namespace Gamespace.Core.ObjectMode
{
    public class SimpleObject : MonoBehaviour, IPlaceableObject
    {
        public bool isEnabled => _isEnabled;
        public string id => _id;
        public float elevateValue => _elevateValue;
        public float lookPercentage { get; set; }
        public float distanceFromPlayer { get; set; }
        public PlaceType placeType => _placeType;
        public Collider collider => _collider;
        public Vector3 position => _model.transform.position;
        public Vector3 center => _collider.bounds.center;
        public Quaternion rotateValue => _rotateValue;
        public Quaternion rotation => _model.transform.rotation;
        public IMaterialSwapper linkMaterialSwapper => _linkMaterialSwapper;
        public IMaterialSwapper placingMaterialSwapper => _placingMaterialSwapper;
        public IActionBehaviour[] actionBehaviours => _actionBehaviours;

        [SerializeField] private string _id;
        [SerializeField] private PlaceType _placeType;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _model;
        [SerializeField] private GameObject _linkMaterialSwapperObject;
        [SerializeField] private GameObject _placingMaterialSwapperObject;
        [SerializeField] private Transform _actionGroupParent;
        [SerializeField] private SerializableReference _serializableReference;
        
        private bool _isEnabled;
        private float _elevateValue;
        private SignalBus _signalBus;
        private Quaternion _rotateValue;
        private Vector3 _originalModelPosition;
        private IPlaceableSurface _surface;
        private IMaterialSwapper _linkMaterialSwapper;
        private IMaterialSwapper _placingMaterialSwapper;
        private IActionBehaviour[] _actionBehaviours;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public virtual void SetActive(bool enabled)
        {
            _isEnabled = enabled;
            _model.SetActive(_isEnabled);
        }
        public virtual void OnCreateCandidate()
        {
            _rotateValue = Quaternion.Euler(0, 0, 0);
            _originalModelPosition = _model.transform.localPosition;

            if (_placingMaterialSwapperObject != null)
                _placingMaterialSwapper = _placingMaterialSwapperObject.GetComponent<IMaterialSwapper>();

            if (_linkMaterialSwapperObject != null)
                _linkMaterialSwapper = _linkMaterialSwapperObject.GetComponent<IMaterialSwapper>();
        }
        public virtual void SetSpawnCandidatePosition(PlacingData data)
        {
            if (!data.isEnabled)
                data.position.y -= 0.5f;

            transform.position = data.position;
            transform.rotation = Quaternion.Euler(data.normal);
        }
        public virtual void OnInitialize()
        {
            if (string.IsNullOrEmpty(_id))
                _id = NanoId.Generate(8);

            var actionList = new List<IActionBehaviour>();

            for (int i = 0; i < _actionGroupParent.childCount; i++)
            {
                var action = _actionGroupParent.GetChild(i).GetComponent<IActionBehaviour>();

                if (action is null)
                    continue;

                action.OnInitialized(_id, name);
                actionList.Add(action);
            }

            _actionBehaviours = actionList.ToArray();
        }
        public virtual void OnDispose()
        {
            Destroy(gameObject);
        }
        public void SetParent(IPlaceableSurface surface)
        {
            if (surface is null)
                return;
            
            _surface = surface;
            transform.SetParent(_surface.transform);
        }
#if UNITY_EDITOR
        public void EditorSetup(PlaceType placeType, GameObject model, Transform actionGroup)
        {
            _model = model;

            var collider = _model.GetComponent<Collider>();

            if (collider != null)
                _collider = collider;

            _placeType = placeType;
            _actionGroupParent = actionGroup.transform;
        }
#endif
        public void Rotate(Quaternion rotation)
        {
            if (_model == null)
                return;

            _model.transform.rotation *= rotation;
            _rotateValue = rotation;
        }
        public void Elevate(float value)
        {
            if (_model == null)
                return;

            _model.transform.localPosition = new Vector3(0, _originalModelPosition.y + value, 0);
            _elevateValue = value;
        }
        public ObjectData Serialize()
        {
            var data = new ObjectData
            {
                uniqueId = _serializableReference.id,
                instanceId = _id,
                parentObjectId = _surface is null ? "" : _surface.id,
                elevation = _elevateValue,
                position = transform.position,
                rotation = _rotateValue,
            };
            
            return data;
        }
        public void Deserialize(ObjectData data)
        {
            _id = data.instanceId;
            transform.position = data.position;
            
            _model.transform.rotation *= data.rotation;
            _rotateValue = data.rotation;
            
            _model.transform.localPosition = new Vector3(0, _originalModelPosition.y + data.elevation, 0);
            _elevateValue = data.elevation;
        }
    }
}