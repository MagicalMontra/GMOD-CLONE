using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class FloatPerTicksBehaviour : FloatActionBehaviour
    {
        private bool _isUpdated;
        private float _timer;
        private float _previousValue;
        private float _currentValue;
        
        [SerializeField] private FloatActionVariable _ticks = new FloatActionVariable(1f);
        [SerializeField] private FloatActionVariable _thresholdWithinTick = new FloatActionVariable(0.25f);

        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ _ticks, _thresholdWithinTick };
        }
        public override void Perform(float value)
        {
            _currentValue = value;

            if (!_isUpdated)
                OnCalculateValueChange().ToUniTask().Forget();
        }
        private IEnumerator OnCalculateValueChange()
        {
            _isUpdated = true;
            _previousValue = _currentValue;
                
            while (_timer < _ticks.value)
            {
                if (Mathf.Abs(_currentValue - _previousValue) >= _thresholdWithinTick.value)
                {
                    Next(_currentValue);
                    break;
                }

                _timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            _timer = 0;
            _isUpdated = false;
        }
        public override Type[] GetAcceptingTypes()
        {
            var types = new List<Type>
            {
                typeof(IntActionBehaviour),
                typeof(VoidActionBehaviour),
                typeof(FloatActionBehaviour),
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
    }
}