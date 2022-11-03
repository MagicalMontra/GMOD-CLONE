using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionPropertyPanelSetActive : IActionPropertyPanelSetActive
    {
        public bool isEnabled => _settings.panel.activeInHierarchy;
        
        [Inject] private ActionSettings _settings;
        
        public void SetActive(bool enabled)
        {
            _settings.panel.SetActive(enabled);
        }
    }
}