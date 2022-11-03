using Cysharp.Threading.Tasks;
using Gamespace.Utilis.Encryption;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginEncryptionWorker : ILoginEncryptionWorker
    {
        [Inject] private LoginSettings _settings;
        [Inject] private IEncryption _encryption;
        [Inject] private ILoginCredentialWriter _writer;
        [Inject] private ILoginCredentialReader _reader;
        [Inject] private LoginPlayerPrefsMapper _playerPrefsMapper;
        
        public async UniTask<bool> Encrypt(LoginRequestData data)
        {
            var id = await _playerPrefsMapper.GetInstanceId();

            if (!string.IsNullOrEmpty(id))
            {
                var index = 0;
                var insertedPassword = "";
                
                for (int i = 0; i < data.password.Length; i++)
                {
                    insertedPassword += data.password[i];

                    if (i < id.Length - 1)
                    {
                        insertedPassword += id[i];
                        index++;
                    }
                }
                
                for (int i = index; i < id.Length; i++)
                    insertedPassword += id[i];

                data.password = insertedPassword;
                _playerPrefsMapper.ModifyKey(_settings.lengthKey, index);
            }
            
            data.password = await _encryption.Encrypt(data.password);
            var json = JsonUtility.ToJson(data);
            json = await _encryption.Encrypt(json);
            return await _writer.Write(json);
        }
        public async UniTask<LoginRequestData> Decrypt()
        {
            var json = await _reader.Read();
            json = await _encryption.Decrypt(json);
            var data = JsonUtility.FromJson<LoginRequestData>(json);
            data.password = await _encryption.Decrypt(data.password);
            var index = _playerPrefsMapper.GetKey(_settings.lengthKey).AsInt;
            
            var truePassword = "";
            
            for (int i = 0; i < data.password.Length; i++)
            {
                truePassword += data.password[i];
                
                if (i + 1 > (index - 1) * 2)
                    break;
                
                i += 1;
            }

            data.password = truePassword;

            return data;
        }
    }
}