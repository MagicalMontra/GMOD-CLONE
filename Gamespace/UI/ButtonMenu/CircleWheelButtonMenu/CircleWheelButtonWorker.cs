using System;
using System.Collections.Generic;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelButtonWorker
    {
        public int count => _buttons.Count;

        [Inject] private CircleWheelSettings _settings;
        [Inject] private ExtendedWheelButton.Pool _buttonPool;

        private readonly List<ExtendedWheelButton> _buttons = new List<ExtendedWheelButton>();

        public ExtendedWheelButton CreateButton()
        {
            var button = _buttonPool.Spawn(_settings.panel.transform.rotation, _settings.buttonSlot);
            _buttons.Add(button);
            return button;
        }
        public ExtendedWheelButton GetButton(int index)
        {
            return _buttons[index];
        }
        public void RemoveButtons()
        {
            for (int i = 0; i < _buttons.Count; i++)
                _buttonPool.Despawn(_buttons[i]);

            _buttons.Clear();
        }
    }
}