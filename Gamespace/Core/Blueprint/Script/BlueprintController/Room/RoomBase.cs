using System;
using nanoid;
using UnityEngine;
using Gamespace.Core.Serialization;
using Gamespace.Core.Blueprint.Serialization;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.ObjectMode.PlaceableSurface.Serialization;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.Core.Blueprint.Room
{
    public class RoomBase : MonoBehaviour, ISerializable<RoomData>
    {
        public class Factory : PlaceholderFactory<Object, RoomBase> { }
        public string id => _id;
        
        public bool isOverlap;
        public bool isSelected;
        public bool isSnapping;
        public bool isOnBluePrintMode;

        public float mouseDistinace = 10;

        public IMaterialSwapper<int> materialSwapper => _materialSwapper;

        [SerializeField] private float snapMovementSpeed = 10;
        [SerializeField] private Transform centerPos;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider roomCollider;
        [SerializeField] private SerializableReference _serializableReference;

        private string _id;
        private float timer;
        private int rotationStep;
        private Vector3 mousePos;
        private SignalBus _signalBus;
        private RoomBase otherRoomBase;
        private IPlaceableSurface[] _placeableSurfaces;
        private IMaterialSwapper<int> _materialSwapper;

        public void Initialize()
        {
            if (string.IsNullOrEmpty(_id))
                _id = NanoId.Generate(4);
            
            roomCollider ??= GetComponent<Collider>();
            _materialSwapper ??= GetComponent<IMaterialSwapper<int>>();
            _placeableSurfaces ??= GetComponentsInChildren<IPlaceableSurface>();
            
            _materialSwapper.SetOriginalMaterial();
            roomCollider.isTrigger = true;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            roomCollider ??= GetComponent<Collider>();
            _materialSwapper ??= GetComponent<IMaterialSwapper<int>>();
            _placeableSurfaces ??= GetComponentsInChildren<IPlaceableSurface>();
            
            for (int i = 0; i < _placeableSurfaces.Length; i++)
                _signalBus.Fire(new PlaceableSurfaceInitializeSignal(_placeableSurfaces[i]));
        }
        private void Update()
        {
            if (!isSelected)
                return;

            if (!(Vector3.Distance(mousePos, centerPos.position) > mouseDistinace)) 
                return;
            
            isSnapping = false;
        }

        // ...and the mesh finally turns white when the mouse moves away.
        private void OnMouseExit()
        {
            if (isOverlap)
                return;
            
            if (isOnBluePrintMode)
                _materialSwapper.SetActive(0);

        }

        // ...the red fades out to cyan as the mouse is held over...
        private void OnMouseOver()
        {
            if (isOverlap)
                return;
            
            if (isOnBluePrintMode)
                _materialSwapper.SetActive(1);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!isSelected)
            {
                return;
            }
            if (isSnapping)
            {
                return;
            }
            RoomBase room = other.GetComponent<RoomBase>();

            if (room != null)
            {
                isOverlap = false;
                _materialSwapper.SetActive(1);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!isSelected)
            {
                return;
            }

            RoomBase room = other.GetComponent<RoomBase>();

            if (room != null)
            {
                isOverlap = true;
                _materialSwapper.SetActive(2);
            }
        }

        public RoomData Serialize()
        {
            var data = new RoomData
            {
                uniqueId = _serializableReference.id,
                instanceId =  _id,
                position = transform.position,
                rotation = transform.rotation,
                surfaces = new SurfaceData[_placeableSurfaces.Length]
            };

            for (int i = 0; i < data.surfaces.Length; i++)
                data.surfaces[i] = _placeableSurfaces[i].Serialize();

            return data;
        }

        public void Deserialize(RoomData data)
        {
            _id = data.instanceId;
            transform.position = data.position;
            transform.rotation = data.rotation;

            Initialize();
            
            for (int i = 0; i < _placeableSurfaces.Length; i++)
                _placeableSurfaces[i].Deserialize(data.surfaces[i]);
        }
        public void OnSelected()
        {
            _rigidbody.isKinematic = true;
            _materialSwapper.SetActive(1);
            isSelected = true;
        }
        public void OnDeselected()
        {
            _materialSwapper.SetActive(0);
            _rigidbody.isKinematic = true;
            isSelected = false;
            isSnapping = false;
        }
        public void SetMousePosition(Vector3 mPos)
        {
            mousePos = mPos;
        }
        public void FilpRotationRoom()
        {
            rotationStep++;

            if (rotationStep == 4)
            {
                rotationStep = 0;
            }

            if (rotationStep == 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (rotationStep == 1)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (rotationStep == 2)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);

            }
            if (rotationStep == 3)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);

            }
        }
        public bool GetSnapping()
        {
            return isSnapping;
        }
    }
}
