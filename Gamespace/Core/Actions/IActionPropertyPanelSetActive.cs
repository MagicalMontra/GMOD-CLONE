namespace Gamespace.Core.Actions
{
    public interface IActionPropertyPanelSetActive
    {
        bool isEnabled { get; }
        void SetActive(bool enabled);
    }
}