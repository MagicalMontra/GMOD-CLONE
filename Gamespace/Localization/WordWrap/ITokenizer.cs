using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public interface ITokenizer
    {
        void Initialize(TextAsset wordWrapDatabase);
        string InsertLineBreaks(string inputText, char separator = ' ');
        
        public class Factory : PlaceholderFactory<Language, ITokenizer> {}
    }
}