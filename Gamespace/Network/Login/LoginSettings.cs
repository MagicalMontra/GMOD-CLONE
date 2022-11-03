using System;
using UnityEngine;

namespace Gamespace.Network.Login
{
    [Serializable]
    public class LoginSettings
    {
        public string rememberPath;
        public string lengthKey;
        public string instanceKey;
        public string rememberKey;
        public string autoLoginKey;
        public GameObject loginUIPrefab;
        public GameObject autoLoginUIPrefab;
        public Camera uiCamera;
    }
}