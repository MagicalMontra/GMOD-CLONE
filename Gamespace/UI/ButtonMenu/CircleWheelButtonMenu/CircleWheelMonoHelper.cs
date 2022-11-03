using System;
using UnityEngine;

namespace Gamespace.UI
{
    public class CircleWheelMonoHelper : MonoBehaviour
    {
        private bool _neededUpdate;
        private Action _action;
        
        public void SetUpdate(Action action)
        {
            _action = action;
            _neededUpdate = true;
        }

        public void Dispose()
        {
            _neededUpdate = false;
        }
        private void Update()
        {
            if (!_neededUpdate)
                return;

            _action?.Invoke();
        }
    }
}