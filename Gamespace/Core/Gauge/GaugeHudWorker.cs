using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Gamespace.UI.Gauge
{
    public class GaugeHudWorker
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private GaugeHudSetting _gaugeHudSetting;
        [Inject] private GaugeTypeSelector _typeSelector;
        [Inject] private IGaugeUI.Factory _gaugeFactory;

        private List<IGaugeUI> _gauges = new List<IGaugeUI>();

        public void OnGaugeRequest(GaugeRequestSignal signal)
        {
            IGaugeUI gauge = null;
            var index = _gauges.FindIndex(g => g.type == signal.gaugeType);

            if (index > -1)
            {
                gauge?.Despawn();
                gauge = _gauges[index];
                gauge.Reset();
                _signalBus.Fire(new GaugeResponseSignal(signal.requestId, gauge));
                return;
            }

            var gaugePrefab = _typeSelector.GetMatchingType(signal.gaugeType);
            gauge = _gaugeFactory.Create(gaugePrefab, _gaugeHudSetting.canvas.transform);
            _gauges.Add(gauge);
            _signalBus.Fire(new GaugeResponseSignal(signal.requestId, gauge));
        }
    }
}

