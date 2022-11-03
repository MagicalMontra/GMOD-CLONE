
using Cysharp.Threading.Tasks;
using Gamespace.Utilis.Encryption;
using nanoid;
using SimpleJSON;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gamespace.Network.Login
{
    public class LoginPlayerPrefsMapper : IInitializable
    {
        private const string _playerPrefKey = "Login";

        [Inject] private LoginSettings _settings;
        [Inject] private IEncryption _encryption;
        private JSONObject _jsonObject;

        public void ModifyKey(string key, JSONNode value)
        {
            var hasKey = _jsonObject.HasKey(key);

            if (!hasKey)
                _jsonObject.Add(key, value);
            else
                _jsonObject[key] = value;

            PlayerPrefs.SetString(_playerPrefKey, _jsonObject.ToString());
            PlayerPrefs.Save();
        }
        public async UniTask SetInstanceKey()
        {
            var hasInstanceKey = _jsonObject.HasKey(_settings.instanceKey);

            var encryptedInstance = await _encryption.Encrypt(NanoId.Generate(Random.Range(20, 100)));
            
            if (!hasInstanceKey)
                _jsonObject.Add(_settings.instanceKey, encryptedInstance);
            else
                _jsonObject[_settings.instanceKey] = encryptedInstance;
            
            PlayerPrefs.SetString(_playerPrefKey, _jsonObject.ToString());
            PlayerPrefs.Save();

            await UniTask.Yield();
        }
        public JSONNode GetKey(string key)
        {
            return _jsonObject[key];
        }
        public async UniTask<string> GetInstanceId()
        {
            var id = "";
            
            if (_jsonObject.HasKey(_settings.instanceKey))
                id = await _encryption.Decrypt(_jsonObject[_settings.instanceKey]);
                
            return id;
        }
        public void Initialize()
        {
            _jsonObject = new JSONObject();
            var json = JSONNode.Parse(PlayerPrefs.GetString(_playerPrefKey));

            foreach (var keyPair in json)
                _jsonObject.Add(keyPair.Key, keyPair.Value);
        }
    }
}