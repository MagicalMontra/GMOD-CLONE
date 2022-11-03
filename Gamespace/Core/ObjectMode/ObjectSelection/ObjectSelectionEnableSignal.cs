namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionEnableSignal : IObjectSelectionEnableSignal
    {
        public string id => _id;
        private string _id;
        public ObjectSelectionEnableSignal(string id)
        {
            _id = id;
        }
    }

    public class ObjectSelectionDisableSignal : IObjectSelectionDisableSignal
    {
        public string id => _id;
        private string _id;
        
        public ObjectSelectionDisableSignal(string id)
        {
            _id = id;
        }
    }
}