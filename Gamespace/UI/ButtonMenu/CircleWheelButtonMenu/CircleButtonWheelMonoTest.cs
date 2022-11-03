using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleButtonWheelMonoTest : MonoBehaviour
    {
        [SerializeField] private List<string> _ids = new List<string>();
        
        [Inject] private SignalBus _signalBus;
        
        public void Invoke()
        {
            var actions = new List<CircleWheelAction>();

            for (int i = 0; i < _ids.Count; i++)
            {
                var amount = i;
                actions.Add(new CircleWheelAction(_ids[amount], () => ActionTest(_ids[amount])));
            }
            
            _signalBus.AbstractFire(new CircleWheelOpenSignal(null, actions.ToArray()));
        }
        private void ActionTest(string s)
        {
            Debug.Log(s);
            gameObject.SetActive(false);
        }
    }
}