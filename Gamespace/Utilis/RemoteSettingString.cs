using System;
using UnityEngine;

namespace Gamespace.Utilis
{
    [Serializable]
    public class RemoteSettingString : IRemoteSettingsKeyPair<string>
    {
        public string key;
        [SerializeField] private string defaultValue;

        public string Value
        {
            get { return RemoteSettings.GetString(key, defaultValue); }
        }
    }
}