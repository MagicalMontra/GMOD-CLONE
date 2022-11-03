using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class StreamLoginCredentialWriter : ILoginCredentialWriter
    {
        [Inject] private LoginSettings _settings;
        
        public async UniTask<bool> Write(string data)
        {
            try
            {
                StreamWriter file = new StreamWriter($"{Application.persistentDataPath}/{_settings.rememberPath}");
                await file.WriteLineAsync(data);
                file.Close();
            }
            catch (Exception e)
            {
#if UNITY_EDITOR
                Debug.Log(e.ToString());
#endif
                return false;
            }
            return true;
        }
    }
}