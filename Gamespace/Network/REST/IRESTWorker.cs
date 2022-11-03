using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Gamespace.Network.RestAPI
{
    public interface IRESTWorker
    {
        UniTask<string> Handle(UnityWebRequest _request);
    }
}