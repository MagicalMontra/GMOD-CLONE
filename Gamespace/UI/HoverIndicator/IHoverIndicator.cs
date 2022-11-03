using UnityEngine;
using Zenject;

namespace Gamespace.UI.HoverIndicator
{
    public interface IHoverIndicator
    {
        void Disable();
        void Enable(string indicatorText);
        void UpdatePosition(Vector3 position);
        
        public class Factory : PlaceholderFactory<Object, Transform, IHoverIndicator>
        {
            
        }
    }
}