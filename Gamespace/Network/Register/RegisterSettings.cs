using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gamespace.Network.Register
{
    [Serializable]
    public class RegisterSettings
    {
        public Camera mainCamera;
        public UnityEvent loginCaller;
        public GameObject registerUIPrefab;
    }
}