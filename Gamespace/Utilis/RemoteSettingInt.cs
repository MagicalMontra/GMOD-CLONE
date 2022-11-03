using System;
using UnityEngine;

namespace Gamespace.Utilis
{
    [Serializable]
    public class RemoteSettingInt : IRemoteSettingsKeyPair<int>
    {
        public string key;
        [SerializeField] private int defaultValue;
        
        public int Value
        {
            get { return  RemoteSettings.GetInt(key, defaultValue);}
        }
    }
}