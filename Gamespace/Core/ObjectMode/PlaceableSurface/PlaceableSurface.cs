using nanoid;
using Zenject;
using UnityEngine;
using Gamespace.Core.ObjectMode.PlaceableSurface.Serialization;

namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public class PlaceableSurfaceInitializeSignal
    {
        public IPlaceableSurface surface => _surface;
        private IPlaceableSurface _surface;

        public PlaceableSurfaceInitializeSignal(IPlaceableSurface surface)
        {
            _surface = surface;
        }
    }
    public class PlaceableSurfaceDisposeRequestSignal
    {
        public string id => _id;
        private string _id;
    
        public PlaceableSurfaceDisposeRequestSignal()
        {
            _id = "";
        }
        public PlaceableSurfaceDisposeRequestSignal(string id)
        {
            _id = id;
        }
    }

    public class PlaceableSurfaceDisposeResponseSignal
    {
        
    }
    public class PlaceableSurface : MonoBehaviour, IPlaceableSurface
    {
        public string id => _id;
        public float lookThreshold => _lookThreshold;
        public float lookPercentage { get; set; }
        public float distanceFromPlayer { get; set; }
        public PlaceType placeType => _placeType;
        public Transform transform => gameObject.transform;

        public Collider collider => _collider;

        private SignalBus _signalBus;

        [SerializeField] private string _id;
        [SerializeField] private float _lookThreshold = 0.5f;
        [SerializeField] private PlaceType _placeType;
        [SerializeField] private Collider _collider;

        private bool _isInitialized;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            if(_signalBus == null)
                return;
            
            _isInitialized = true;
        }
        public void OnInitialize()
        {
            if (string.IsNullOrEmpty(_id))
                _id = NanoId.Generate(6);
        }
        public void OnDispose()
        {
            Destroy(gameObject);
        }
        public SurfaceData Serialize()
        {
            var data = new SurfaceData
            {
                id = _id,
            };

            return data;
        }
        public void Deserialize(SurfaceData data)
        {
            _id = data.id;
        }
    }
}