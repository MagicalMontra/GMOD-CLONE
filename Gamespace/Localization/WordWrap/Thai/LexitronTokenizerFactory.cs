using Zenject;

namespace Gamespace.Localization
{
    public class LexitronTokenizerFactory : IFactory<Language, ITokenizer>
    {
        private const string _mode = "th-TH";
        private DiContainer _container;
        private DefaultTokenizer.Factory _defaultFactory;
        
        public LexitronTokenizerFactory(DiContainer container, DefaultTokenizer.Factory defaultFactory)
        {
            _container = container;
            _defaultFactory = defaultFactory;
        }
        public ITokenizer Create(Language language)
        {
            if (_mode == language.name)
            {
                var instance = _container.Instantiate<LexitronTokenizer>();
                instance.Initialize(language.wordWrapDatabase);
                return instance;
            }

            return _defaultFactory.Create(language);
        }
    }
}