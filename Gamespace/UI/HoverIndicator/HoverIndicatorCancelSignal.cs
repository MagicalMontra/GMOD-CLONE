namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorCancelSignal
    {
        public string name => _name;
        private string _name;
        public HoverIndicatorCancelSignal(string name)
        {
            _name = name;
        }
    }
}