using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Gamespace.Utilis.Encryption
{
    public class Base64Encryption : IEncryption
    {
        public async UniTask<string> Encrypt(string data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            
            await Task.Run(() =>
            {
                formatter.Serialize(ms, data);
            });
            
            return Convert.ToBase64String(ms.ToArray());
        }
        public async UniTask<string> Decrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
                return "";

            string deserializedData = data;
            
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(data));
            
            await Task.Run(() =>
            {
                deserializedData = formatter.Deserialize(ms).ToString();
            });

            return deserializedData;
        }
    }
}