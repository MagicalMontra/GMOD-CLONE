using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectHoverRequestSignal
    {
        public string name => _name;
        public RectTransform rect => _rect;
        private string _name;
        private RectTransform _rect;
        public PlaceableObjectHoverRequestSignal(string name, RectTransform rect)
        {
            _name = name;
            _rect = rect;
        }
    }

    public class PlaceableObjectHoverCancelSignal
    {
        
    }
}