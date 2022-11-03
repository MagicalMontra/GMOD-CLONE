using UnityEngine;

namespace Gamespace.UI.HoverIndicator
{
    public class HoverIndicatorRequestSignal
    {
        public string name => _name;
        public string translateClusterName => _translateClusterName;
        public RectTransform rect => _rect;
        
        private string _name;
        private string _translateClusterName;
        private RectTransform _rect;
        
        public HoverIndicatorRequestSignal(string name, string translateClusterName, RectTransform rect)
        {
            _name = name;
            _translateClusterName = translateClusterName;
            _rect = rect;
        }
    }
}