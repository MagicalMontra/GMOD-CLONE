using System;
using Gamespace.Localization;
using Gamespace.Utilis;
using UnityEngine;

namespace Gamespace.Network
{
    [Serializable]
    public class NetworkSettings
    {
        public string languageCluster;
        public string localPath = "/session.txt";
        public int accessTokenExpireHours = 24;
        public int refreshTokenExpireHours = 168;
        public RemoteSettingString urlGateWay;
        public bool neededVersion = false;
        public RemoteSettingString apiVersion;
        public bool neededPort = false;
        public RemoteSettingInt apiPort;
    }
}