using Zenject;

namespace Gamespace.Localization
{
    public class DefaultWordWrapWorkerFactory : IFactory<ITokenizer, Language, IWordWrapWorker>
    {
        private DiContainer _container;
        
        public DefaultWordWrapWorkerFactory(DiContainer container)
        {
            _container = container;
        }
        public IWordWrapWorker Create(ITokenizer tokenizer, Language mode)
        {
            var instance = _container.Instantiate<DefaultWordWrapWorker>();
            instance.Initialize(tokenizer);
            return instance;
        }
    }
}