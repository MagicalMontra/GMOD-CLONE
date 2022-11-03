using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Register
{
    public class RegisterRequestWorker
    {
        [Inject] private IDataStore _dataStore;

        public async UniTask<TEntity<UserData>> Request(RegisterRequestData data)
        {
            var response = await _dataStore.Post<UserData>(data, "api/account/register");
            Debug.Log(response.data.email + " " + response.error.ToString());
            return response;
        }
    }
}