using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Gamespace.Network
{
    public class NetworkTextureHandler
    {
        public async Task<Texture2D> Request(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            var asyncOperation = request.SendWebRequest();
            while (!asyncOperation.isDone)
            {
                await Task.Delay(Mathf.CeilToInt(1000 / 30));
            }

            if (request.result == UnityWebRequest.Result.Success)
                return DownloadHandlerTexture.GetContent(request);
            else
            {
#if UNITY_EDITOR || DEBUG
                Debug.Log($"{request.error}, URL:{request.url}");
#endif
                return null;
            }
            
        }
    }
}