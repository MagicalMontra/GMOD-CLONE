using System;
using Zenject;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Gamespace.UI.ProgressScreen;
using Unity.Plastic.Newtonsoft.Json;

namespace Gamespace.Core.Serialization
{
    public abstract class SerializationReader<TContract> : ISerializationReader<TContract>
    {
        public SerializationMap map => _settings.map;

        [Inject] private SignalBus _signalBus;
        [Inject] private SerializationSettings _settings;

        private string _lastLoadedId;
        public abstract UniTask<TContract> Read(string key);

        public abstract UniTask<TContract[]> ReadAll();
        protected async UniTask Read()
        {
            var filePath = $"{Application.persistentDataPath}/{_settings.filePath}/{_settings.fileName}.worklabs";
            if (!File.Exists(filePath))
            {
#if UNITY_EDITOR
                Debug.Log($"Path doesn't exist {filePath}");
#endif
                await UniTask.Yield();
                return;
            }

            if (!string.IsNullOrEmpty(_lastLoadedId) && _settings.map.id == _lastLoadedId)
            {
                await UniTask.Yield();
                return;
            }
            
            _settings.map = new SerializationMap();

            StreamReader file = new StreamReader(filePath);
            var readTask = file.ReadToEndAsync().AsUniTask();
            var progressTask = UniTask.Run(async () =>
            {
                while (file.BaseStream.Position < file.BaseStream.Length)
                {
                    await UniTask.Delay(TimeSpan.FromMilliseconds(100));
                    _signalBus.Fire(new ProgressScreenRequestSignal((int)file.BaseStream.Position, (int)file.BaseStream.Length, $"Initializing {_settings.fileName}"));
                }
            });
            
            await UniTask.WhenAll(readTask, progressTask);
            var json = await readTask;
            
            await UniTask.Delay(TimeSpan.FromMilliseconds(400));
            _signalBus.Fire(new ProgressScreenCompleteSignal($"Initialized {_settings.fileName}"));

            file.Close();
            
            var data = JsonConvert.DeserializeObject<SerializationMap>(json);
            
            if (data is null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("data is null");
#endif
                await UniTask.Yield();
                return;
            }

            _lastLoadedId = data.id;
            _settings.map = data;
            await UniTask.Yield();
        }
    }
}