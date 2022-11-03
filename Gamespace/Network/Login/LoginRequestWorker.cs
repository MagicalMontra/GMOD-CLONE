using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginRequestWorker
    {
        [Inject] private IDataStore _dataStore;

        public async UniTask<TEntity<AccessToken>> Request(LoginRequestData data)
        {
            var response = await _dataStore.Post<AccessToken>(data, "api/account/login");
            return response;
        }
    }
}