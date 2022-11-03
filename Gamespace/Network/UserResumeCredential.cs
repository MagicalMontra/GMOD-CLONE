using System;

namespace Gamespace.Network
{
    [Serializable]
    public class UserResumeCredential
    {
        public string name;
        public string accessToken;
        public string refreshToken;
        public long lastStamp = DateTime.Now.Ticks;
    }
}