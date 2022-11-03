using Zenject;

namespace Gamespace.Core.ObjectMode.Elevation
{
    public class ObjectElevationIndicatorWorker
    {
        [Inject] private ObjectElevationSettings _settings;

        public void SetText(float value)
        {
            _settings.indicatorText.text = "+" + value.ToString("F2");
        }
    }
}