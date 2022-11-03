using nanoid;
using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public class ZPullableObject : PullableObject
    {
        public override void Pull(float pullAmount)
        {
            if (!isPulling)
                return;

            pullAmount *= _speed;
            _value += pullAmount;
            events.Invoke(_value);

            if (_value >= maxValue)
                _value = maxValue;

            if (_value <= minValue)
                _value = minValue;

            if (_gauge != null)
                _gauge.value = _value;

            var angleZ = _value * _maxAngle;

            if (angleZ >= _maxAngle)
                angleZ = _maxAngle;

            _rotateObject.localEulerAngles = new Vector3(_rotateObject.localEulerAngles.x, _rotateObject.localEulerAngles.y, _offAngle + angleZ);
        }
        public override void OnInitialize()
        {
            base.OnInitialize();
            _speed = 1 / (1000 + (float)(maxValue - minValue) * 5);
            maxValue = maxValue > 1 ? maxValue / maxValue : 1;
            _maxAngle = _onAngle - _offAngle;
            _rotateObject.localEulerAngles = new Vector3(_rotateObject.localEulerAngles.x, _rotateObject.localEulerAngles.y, _offAngle);
        }
    }

}

