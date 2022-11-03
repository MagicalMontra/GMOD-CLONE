using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class DefaultTokenizer : ITokenizer
    {
        public void Initialize(TextAsset wordWrapDatabase)
        {

        }

        public string InsertLineBreaks(string inputText, char separator = ' ')
        {
            return inputText;
        }
        
        public class Factory : PlaceholderFactory<Language, ITokenizer> {}
    }
}