using UnityEngine;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public class ZRotateEulerAxisWorker : IRotateAxisWorker
    {
        public float value => _value;
        private float _value;
        public Quaternion Rotate(float value)
        {
            if (_value + value > 360)
                _value = 0 + value;
            else if (_value + value < 0)
                _value = 360 + value;
            else
                _value += value;
            
            return Quaternion.Euler(0, 0, value);
        }
        public Quaternion Reset()
        {
            var euler = Quaternion.Euler(0, 0, -_value);
            _value = 0;
            return euler;
        }
    }
}