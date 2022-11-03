using System.Collections;
using UnityEngine;
using nanoid;
using Zenject;
using TMPro;

namespace Gamespace.UI.Gauge
{
    public class ForceGuageTest : MonoBehaviour
    {
        [Inject] SubtitleWorker _subtitleWorker;

        public float guageValue;
        private string _gaugeId;
        private IGaugeUI _gauge;
        private SignalBus _signalBus;

        private bool _isRun;

        [Inject]
        public void Constuct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GaugeResponseSignal>(OnGaugeResponse);
            Test();
        }
         private void OnGaugeResponse(GaugeResponseSignal signal)
        {
            if (_gaugeId != signal.requestId)
                return;

            _gauge = signal.gauge;

        }
        public void Test()
        {
            _gaugeId = NanoId.Generate(4);
            _signalBus?.Fire(new GaugeRequestSignal(_gaugeId, typeof(VerticalGaugeUI)));
        }

         private void Update()
        {
            if (_gauge is null)
                return;

            if(!_isRun)
            {
                _gauge.value = guageValue;
        
                _isRun = true;
            }

        }

    }

}
