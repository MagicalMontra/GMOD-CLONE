using System;
using Gamespace.Network.RestAPI;

namespace Gamespace.Network.Register
{
    [Serializable]
    public class RegisterRequestData
    {
        public string firstname;
        public string lastname;
        public string email;
        public string mobile;
        public string password;
    }
}
