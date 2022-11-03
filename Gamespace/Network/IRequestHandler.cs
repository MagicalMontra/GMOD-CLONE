using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Gamespace.Network
{
    public interface IRequestHandler<T>
    {
        UnityWebRequest CreateRequest(string url, string method, T data);
    }
    public class JsonRequest : IRequestHandler<object>
    {
        [Inject] private NetworkCredential _settings;
        
        public UnityWebRequest CreateRequest(string url, string method, object data = null)
        {
            UnityWebRequest req = new UnityWebRequest();

            if (!string.IsNullOrEmpty(_settings.AccessToken))
                req.SetRequestHeader("authorization", "Bearer " + _settings.AccessToken);
            
            if (data != null)
                req.uploadHandler = HttpUtility.HandleData(data);

            req.SetRequestHeader("Content-Type", "application/json");
            req.timeout = 5;
            req.downloadHandler = new DownloadHandlerBuffer();
            req.url = url;
            req.method = method;
            return req;
        }
    }

    public class FormRequest : IRequestHandler<string>
    {
        [Inject] private NetworkCredential _settings;
        
        public UnityWebRequest CreateRequest(string url, string method, string data)
        {
            UnityWebRequest req = new UnityWebRequest();
            
            if (!string.IsNullOrEmpty(_settings.AccessToken))
                req.SetRequestHeader("authorization", "Bearer " + _settings.AccessToken);
            
            req.uploadHandler = new UploadHandlerFile(data);
            req.timeout = 15;
            req.downloadHandler = new DownloadHandlerBuffer();
            req.url = url;
            req.method = method;
            return req;
        }
    }

}