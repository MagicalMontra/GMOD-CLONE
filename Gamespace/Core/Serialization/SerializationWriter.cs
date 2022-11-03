using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Gamespace.UI.ProgressScreen;
using nanoid;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public class SerializationWriter : ISerializationWriter
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private SerializationSettings _settings;
        
        public async UniTask<bool> Write()
        {
            if (_settings.map is null)
                _settings.map = new SerializationMap();

            _settings.map.id = await NanoId.GenerateAsync(8).AsUniTask();
            var filePath = ConstructPath();
            StreamWriter file = new StreamWriter(filePath);
            var json = JsonConvert.SerializeObject(_settings.map, Formatting.Indented);
            _signalBus.Fire(new ProgressScreenRequestSignal(0, 1, $"Saving {_settings.fileName}"));
            var writeTask = file.WriteAsync(json).AsUniTask();
            await writeTask;

            _signalBus.Fire(new ProgressScreenCompleteSignal($"Saved {_settings.fileName}"));
            file.Close();
            return writeTask.Status.IsCompletedSuccessfully();
        }
        protected string ConstructPath()
        {
            var directoryInfo = new DirectoryInfo($"{Application.persistentDataPath}/{_settings.filePath}/");
            if (!directoryInfo.Exists)
                Directory.CreateDirectory($"{Application.persistentDataPath}/{_settings.filePath}");

            return $"{directoryInfo.FullName}/{_settings.fileName}.worklabs";
        }
    }
}