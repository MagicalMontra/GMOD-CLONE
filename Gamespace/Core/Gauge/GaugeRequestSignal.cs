using System;

namespace Gamespace.UI.Gauge
{
    public class GaugeRequestSignal
    {
        public string requestId => _requestId;
        public Type gaugeType => _gaugeType;
        private string _requestId;
        private Type _gaugeType;

        public GaugeRequestSignal(string requestId, Type gaugeType)
        {
            _requestId = requestId;
            _gaugeType = gaugeType;
        }
    }

    public class GaugeResponseSignal
    {
        public string requestId => _requestId;
        public IGaugeUI gauge => _gauge;
        private string _requestId;
        private IGaugeUI _gauge;

        public GaugeResponseSignal(string requestId, IGaugeUI gauge)
        {
            _requestId = requestId;
            _gauge = gauge;
        }
    }
}
