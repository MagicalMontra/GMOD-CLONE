using System.Collections;
using System.Collections.Generic;
using nanoid;
using UnityEngine;
using Zenject;
namespace Gamespace.UI.Gauge
{
    public class GaugeTest : MonoBehaviour
    {
        private string _gaugeId;
        private float g = 0;
        private IGaugeUI _gauge;
        private SignalBus _signalBus;

        [Inject]
        public void Constuct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GaugeResponseSignal>(OnGaugeResponse);
            Test();
        }
        public void Test()
        {
            _gaugeId = NanoId.Generate(4);
            _signalBus?.Fire(new GaugeRequestSignal(_gaugeId, typeof(HorizonGaugeUI)));
        }
        private void OnGaugeResponse(GaugeResponseSignal signal)
        {
            if (_gaugeId != signal.requestId)
                return;

            _gauge = signal.gauge;
        }
        private void Update()
        {
            if (_gauge is null)
                return;

            if (Input.GetKey(KeyCode.Space))
            {
                g += Time.deltaTime / 2;
            }
            else
            {
                g -= Time.deltaTime / 2;

            }
            if (g < 0)
            {
                g = 0;
            }
            if (g > 1)
            {
                g = 1;
            }
            _gauge.value = g;
        }
    }
}
