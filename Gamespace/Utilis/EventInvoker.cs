using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Gamespace.Core.Utils
{
    public class EventInvoker : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private UnityEvent _event;
        [SerializeField] private InvokeCycle _invokeCycle;

        private async void Awake()
        {
            if (_invokeCycle == InvokeCycle.Awake)
            {
                await Task.Delay(Mathf.CeilToInt(1000 * _delay));
                _event.Invoke();
            }
        }

        private async void Start()
        {
            if (_invokeCycle == InvokeCycle.Start)
            {
                await Task.Delay(Mathf.CeilToInt(1000 * _delay));
                _event.Invoke();
            }
        }

        public async void Invoke()
        {
            await Task.Delay(Mathf.CeilToInt(1000 * _delay));
            _event.Invoke();
        }

        public enum InvokeCycle
        {
            None = 0,
            Awake,
            Start
        }
    }
}
