using System;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Gamespace.Network.RestAPI
{
    public class RESTWorker : IRESTWorker
    {
        public async UniTask<string> Handle(UnityWebRequest request)
        {
            var operation = await request.SendWebRequest();
            var json = "";

            if (operation.result == UnityWebRequest.Result.ConnectionError)
                json = $"{{\"error\": {{\"statusCode\": {operation.responseCode},\"error\": {operation.error}, \"message\": {operation.result}\"\"}}}}";
            else
                json = operation.downloadHandler.text;

            // Workaround for decoding a UserDataCollection
            if (json.StartsWith("[", StringComparison.CurrentCulture))
                json = "{\"data\": " + json + "}";

#if UNITY_EDITOR || UNITY_INCLUDE_TESTS
            Debug.Log(operation.url + " " + json);
#endif
            operation.Abort();
            operation.Dispose();

            return json;
        }
    }
}