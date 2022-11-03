using Zenject;

namespace Gamespace.Network
{
    public class NetworkCredential : IInitializable, ILateDisposable
    {
        public string AccessToken => _accessToken;
        private string _accessToken;
        public void Initialize()
        {
            
        }

        public void LateDispose()
        {
            
        }
    }
}