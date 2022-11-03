using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class DefaultRotateAxisIndicator : IRotateAxisIndicator
    {
        [Inject] private ObjectRotationSettings _settings;
        private List<string> _axisName = new List<string>();
        
        public void SetAngle(int angle)
        {
            _settings.indicatorText.text = $"{Mathf.Abs(angle)}º";
        }

        public void Initialize()
        {
            _axisName.Add("X");
            _axisName.Add("Y");
            _axisName.Add("Z");
        }
        public void SetAxis(int index)
        {
            _settings.axisText.text = _axisName[index];
        }
        
    }
}