using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public interface ILoginUI
    {
        void OnCreate(bool isRemembered, string email, Camera uiCamera);
        void SetActive(bool enabled);

        public class Factory : PlaceholderFactory<Object, ILoginUI>
        {
            
        }
    }
}