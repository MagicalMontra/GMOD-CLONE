using System.Threading.Tasks;
using Gamespace.Network.RestAPI;
using UnityEngine;
using Zenject;

namespace Gamespace.Network
{
    public class TokenRenewer
    {
        [Inject] private JsonRequest _request;
        [Inject] private IRESTWorker _worker;
        [Inject] private UrlHandler _urlHandler;
        
        public async Task<TEntity<T>> Post<T>(object data, string segments = "api/account/accesstoken/generate")
        {
            var url = _urlHandler.Handle(segments);
            var request = _request.CreateRequest(url,"POST", data);
            var entity = JsonUtility.FromJson<TEntity<T>>(await _worker.Handle(request));
            return entity;
        }
    }
}