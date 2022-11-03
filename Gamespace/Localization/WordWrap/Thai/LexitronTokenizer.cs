using System.Collections;
using System.IO;
using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class LexitronTokenizer : ITokenizer
    {
        [Inject] private IDictionary _dictionary;

        private bool _isInitialized;
        private TextAsset _database;
        
        private void TryInitialize() 
        {
            if (_database != null)
            {
                byte[] data = _database.bytes;
                Load(data);
            }
        }
        private void Load(byte[] data)
        {
            if (data == null || data.Length <= 0) return;
            
            using (var sr = new StreamReader(new MemoryStream(data)))
                _dictionary.Initialize(sr);

            _isInitialized = true;
        }
        public string InsertLineBreaks(string inputText, char separator = ' ') 
        {
            if (!_isInitialized) 
                return inputText;
            
            var result = "";
            ArrayList typeList;
            int begin, end, type;

            _dictionary.WordInstance(inputText);
            typeList = _dictionary.typeList;
            begin = _dictionary.first;
            int i = 0;
            while (_dictionary.hasNext)
            {
                end = _dictionary.next;
                type = (short)typeList[i];
                result += inputText.Substring(begin, end - begin) + separator;
                begin = end;
            }
            return result;
        }
        public void Initialize(TextAsset wordWrapDatabase)
        {
            _database = wordWrapDatabase;
            TryInitialize();
        }
        
        public class Factory : PlaceholderFactory<Language, IWordWrapWorker> {}
    }
}