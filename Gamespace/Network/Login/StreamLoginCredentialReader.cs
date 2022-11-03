using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class StreamLoginCredentialReader : ILoginCredentialReader
    {
        [Inject] private LoginSettings _settings;
        
        public async UniTask<string> Read()
        {
            StreamReader file = new StreamReader($"{Application.persistentDataPath}/{_settings.rememberPath}");
            var data = await file.ReadToEndAsync();
            file.Close();
            return data;
        }
    }
}