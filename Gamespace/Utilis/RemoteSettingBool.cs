using System;
using UnityEngine;

namespace Gamespace.Utilis
{
    [Serializable]
    public class RemoteSettingBool : IRemoteSettingsKeyPair<bool>
    {
        public string key;
        public bool defaultValue;

        public bool Value
        {
            get { return RemoteSettings.GetBool(key, defaultValue); }
        }
    }
}