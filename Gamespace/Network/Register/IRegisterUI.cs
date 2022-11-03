using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.Network.Register
{
    public interface IRegisterUI
    {
        void OnCreate(Camera uiCamera, Action closeAction);
        void SetActive(bool enabled);
        public class Factory : PlaceholderFactory<Object, IRegisterUI>
        {
            
        }
    }
}