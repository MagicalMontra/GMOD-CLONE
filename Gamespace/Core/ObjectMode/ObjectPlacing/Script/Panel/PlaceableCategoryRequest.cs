namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableCategoryRequest
    {
        public string name => _name;
        private string _name;

        public PlaceableCategoryRequest(string name)
        {
            _name = name;
        }
    }
}