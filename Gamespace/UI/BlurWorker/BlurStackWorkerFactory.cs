using LeTai.Asset.TranslucentImage;
using Zenject;

namespace Gamespace.UI
{
    public class BlurStackWorkerFactory : IFactory<ScalableBlurConfig, BlurStackWorker>
    {
        private DiContainer _container;
        public BlurStackWorkerFactory(DiContainer container)
        {
            _container = container;
        }
        public BlurStackWorker Create(ScalableBlurConfig language)
        {
            var instance = _container.Instantiate<BlurStackWorker>();
            instance.Intialize(language);
            return instance;
        }
    }
}