using System.Text.RegularExpressions;
using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class DefaultWordWrapWorker : IWordWrapWorker
    {
        public void Initialize(ITokenizer tokenizer)
        {
            
        }
        public string Wrap(string value, float boxWidth, Font font)
        {
            value = value.Replace("\\n", "\n");
            string result = value;
            return Regex.Unescape(result);
        }
        
        public class Factory : PlaceholderFactory<ITokenizer, Language, IWordWrapWorker> {}
    }
}