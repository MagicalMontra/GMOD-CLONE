using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectUIButtonPool
    {
        [Inject] private PlaceableObjectPanelSettings _settings;
        [Inject] private PlaceableObjectUIButton.Factory _buttonFactory;
        
        private List<PlaceableObjectUIButton> _actives = new List<PlaceableObjectUIButton>();
        private List<PlaceableObjectUIButton> _disables = new List<PlaceableObjectUIButton>();

        public PlaceableObjectUIButton Get(PlaceableObjectData data)
        {
            PlaceableObjectUIButton button;

            if (_disables.Count <= 0)
            {
                button = _buttonFactory.Create(_settings.button, _settings.buttonSlot);
                button.Setup(data);
                _actives.Add(button);
                return _actives[_actives.Count - 1];
            }

            button = _disables[0];
            button.gameObject.SetActive(true);
            button.Setup(data);
            _actives.Add(button);
            _disables.RemoveAt(0);
            return button;
        }
        public void Dispose()
        {
            for (int i = 0; i < _actives.Count; i++)
            {
                _actives[i].gameObject.SetActive(false);
                _disables.Add(_actives[i]);
            }
            
            _actives.Clear();
        }
    }
}