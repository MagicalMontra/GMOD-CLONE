using Zenject;

namespace Gamespace.Localization
{
    public class DefaultTokenizerFactory : IFactory<Language, ITokenizer>
    {
        private DiContainer _container;
        
        public DefaultTokenizerFactory(DiContainer container)
        {
            _container = container;
        }
        public ITokenizer Create(Language language)
        {
            var instance = _container.Instantiate<DefaultTokenizer>();
            instance.Initialize(language.wordWrapDatabase);
            return instance;
        }
    }
}