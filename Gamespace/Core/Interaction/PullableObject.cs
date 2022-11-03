using Gamespace.UI.Gauge;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gamespace.Core.Interaction
{
    public abstract class PullableObject : InteractableObject, IPullable
    {
        public float value => _value;
        public float lookThreshold => _lookThreshold;
        public int maxValue = 1;
        public int minValue;

        public UnityEvent<float> events;

        public bool isPulling => _isPulling;
        public Vector3 position => transform.position;
        public new GameObject gameObject => base.gameObject;

        protected float _value = 0f;
        protected float _maxAngle = 0;
        protected float _speed;

        private bool _isPulling;
        protected IGaugeUI _gauge;
        [SerializeField] private float _lookThreshold;
        [SerializeField] protected float _offAngle = -40f;
        [SerializeField] protected float _onAngle = 40f;
        [SerializeField] protected Transform _rotateObject;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GaugeResponseSignal>(OnGaugeResponse);
        }

        public override void SetActive(bool enabled)
        {
            base.SetActive(enabled);
            _isPulling = enabled;
            
            if (enabled is true)
                return;
            
            _gauge.Despawn();
            _gauge = null;
        }
        public override void Interact()
        {
            base.Interact();

            _isPulling = !_isPulling;

            if (_gauge is null)
            {
                _signalBus.Fire(new GaugeRequestSignal(id, typeof(VerticalGaugeUI)));
                return;
            }
            _gauge.Despawn();
            _gauge = null;
        }
        public abstract void Pull(float pullAmount);
        public override void OnDispose()
        {
            _signalBus.Fire(new InteractableDisposeSignal(id));
            base.OnDispose();
        }
        public override void OnInitialize()
        {
            base.OnInitialize();
            _signalBus.Fire(new InteractableInitializeSignal(this));
        }
        private void OnGaugeResponse(GaugeResponseSignal signal)
        {
            if (id != signal.requestId)
                return;

            _gauge = signal.gauge;
        }
    }

}

