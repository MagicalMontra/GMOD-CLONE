using System;
using System.Collections.Generic;

namespace Gamespace.Network
{
    [Serializable]
    public class UserSession
    {
        public string accessToken;
        public string refreshToken;
        public UserCredential user;
    }

    [Serializable]
    public class UserCredential
    {
        public string name;
        public string email;
        public string avatar;
        public string country;
        public int userRole;
        public int gameplayId;
    }
}