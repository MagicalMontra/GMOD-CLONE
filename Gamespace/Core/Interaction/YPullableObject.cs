using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public class YPullableObject:PullableObject
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

            var angleY = _value * _maxAngle;

            if (angleY >= _maxAngle)
                angleY = _maxAngle;

            _rotateObject.localEulerAngles = new Vector3(_rotateObject.localEulerAngles.x,  _offAngle + angleY,_rotateObject.localEulerAngles.z);
        }
        public override void OnInitialize()
        {
            base.OnInitialize();

            _speed = 1 / (1000 + (float)(maxValue - minValue) * 5);
            maxValue = maxValue > 1 ? maxValue / maxValue : 1;
            _maxAngle = _onAngle - _offAngle;
            _rotateObject.localEulerAngles = new Vector3(_rotateObject.localEulerAngles.x, _offAngle, _rotateObject.localEulerAngles.z);
        }
    }

}

