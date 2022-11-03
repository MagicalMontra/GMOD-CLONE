using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.Utilis
{
    public class NonMonoDrawGizmo : MonoBehaviour
    {
        public Action drawGizmo;
        private void OnDrawGizmos()
        {
            drawGizmo?.Invoke();
        }
        
        public class Factory : PlaceholderFactory<NonMonoDrawGizmo>{}
    }
}

