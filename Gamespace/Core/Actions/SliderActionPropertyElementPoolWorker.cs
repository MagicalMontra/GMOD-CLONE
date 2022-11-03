using System.Collections.Generic;
using System.Reflection;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class SliderActionPropertyElementPoolWorker
    {
        [Inject] private ActionSettings _settings;
        [Inject] private SliderActionPropertyUIElement.Pool _sliderPool;
        private List<ActionPropertyUIElement> _elements = new List<ActionPropertyUIElement>();

        public ActionPropertyUIElement Spawn(ActionVariable instance, FieldInfo fieldInfo)
        {
            var element = _sliderPool.Spawn(instance, fieldInfo, _settings.propertySlot);
            _elements.Add(element);
            return element;
        }
        public void Despawn()
        {
            for (int i = 0; i < _elements.Count; i++)
                _sliderPool.Despawn(_elements[i]);
            
            _elements.Clear();
        }
    }
}