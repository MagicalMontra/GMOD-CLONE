using System;

namespace Gamespace.Network
{
    [Serializable]
    public class RefreshToken
    {
        public string refreshToken;
        public RefreshToken(){}
        public RefreshToken(RefreshToken token)
        {
            refreshToken = token.refreshToken;
        }
    }
}