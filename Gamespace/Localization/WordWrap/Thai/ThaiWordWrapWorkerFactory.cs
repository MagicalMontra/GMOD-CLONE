using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class ThaiWordWrapWorkerFactory : IFactory<ITokenizer, Language, IWordWrapWorker>
    {
        private const string _mode = "th-TH";
        private DiContainer _container;
        private DefaultWordWrapWorker.Factory _defaultFactory;
        
        public ThaiWordWrapWorkerFactory(DiContainer container, DefaultWordWrapWorker.Factory defaultFactory)
        {
            _container = container;
            _defaultFactory = defaultFactory;
        }
        public IWordWrapWorker Create(ITokenizer tokenizer, Language language)
        {
            if (_mode == language.name)
            {
                var instance = _container.Instantiate<ThaiTextWordWrapWorker>();
                instance.Initialize(tokenizer);
                return instance;
            }

            return _defaultFactory.Create(tokenizer, language);
        }
    }
}