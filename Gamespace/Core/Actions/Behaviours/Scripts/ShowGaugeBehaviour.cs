using System.Collections.Generic;
using Zenject;
using Gamespace.Core.Actions;
using System;
using Gamespace.UI.Gauge;
using nanoid;

namespace Gamespace.Core.Actions
{
    public class ShowGaugeBehaviour : FloatActionBehaviour
    {
        private string _gaugeId;
        private IGaugeUI _gauge;
        
        public override void OnConstruct()
        {
            _signalBus.Subscribe<GaugeResponseSignal>(OnGaugeResponse);
        }
        private void OnGaugeResponse(GaugeResponseSignal signal)
        {
            if (_gaugeId != signal.requestId)
                return;

            _gauge = signal.gauge;
            _gaugeId = NanoId.Generate(4);
            _signalBus?.Fire(new GaugeRequestSignal(_gaugeId, typeof(VerticalGaugeUI)));
        }
        public override Type[] GetAcceptingTypes()
        {
               var types = new List<Type>
            {
                typeof(IntActionBehaviour),
                typeof(VoidActionBehaviour),
                typeof(FloatActionBehaviour),
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
        protected override ActionVariable[] Variables()
        {
            return Array.Empty<ActionVariable>();
        }
        public override void Perform(float value)
        {
            if (_gauge is null)
                return;
            _gauge.value = value;
            Next(value);
        }
    }

}
