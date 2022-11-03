using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public interface IWordWrapWorker
    {
        void Initialize(ITokenizer tokenizer);
        string Wrap(string value, float boxWidth, Font font);
        
        public class Factory : PlaceholderFactory<ITokenizer, Language, IWordWrapWorker> {}
    }
}