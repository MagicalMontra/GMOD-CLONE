using System.Collections.Specialized;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.RestAPI
{
    public class RESTDataStore : IDataStore
    {
        [Inject] private IRESTWorker _worker;
        [Inject] private JsonRequest _request;
        [Inject] private UrlHandler _urlHandler;
        [Inject] private NetworkCredential _credential;
        [Inject] private NetOperationErrorTranslator _errorTranslator;
        
        public async UniTask<TEntity<T>> Post<T>(NameValueCollection query, object data, string segments)
        {
            var url = _urlHandler.Handle(segments, query);
            var request = _request.CreateRequest(url,"POST", data);
            var json = await _worker.Handle(request);
            var response = JsonUtility.FromJson<T>(json);
            var error = JsonUtility.FromJson<NetOperationError>(json);

            if (error.statusCode != 0)
                _errorTranslator.Translate(error);
            
            var entity = new TEntity<T>(response, error);
            return entity;
        }
        public async UniTask<TEntity<T>> Post<T>(object data, string segments)
        {
            var url = _urlHandler.Handle(segments);
            var request = _request.CreateRequest(url,"POST", data);
            var json = await _worker.Handle(request);
            var response = JsonUtility.FromJson<T>(json);
            var error = JsonUtility.FromJson<NetOperationError>(json);
            
            if (error.statusCode != 0)
                _errorTranslator.Translate(error);
            
            var entity = new TEntity<T>(response, error);
            return entity;
        }
        public async UniTask<TEntity<T>> Get<T>(NameValueCollection query, string segments)
        {
            var url = _urlHandler.Handle(segments, query);
            var request = _request.CreateRequest(url,"GET");
            var json = await _worker.Handle(request);
            var response = JsonUtility.FromJson<T>(json);
            var error = JsonUtility.FromJson<NetOperationError>(json);

            if (error.statusCode != 0)
                _errorTranslator.Translate(error);

            var entity = new TEntity<T>(response, error);
            return entity;
        }
    }
}