using System.Collections.Generic;
using Gamespace.Core.Serialization;
using Zenject;

namespace Gamespace.Core.Serialization
{
    public abstract class SerializationQueueWorker<TContract> : ISerializationQueueWorker<TContract>
    {
        protected SerializationMap map => _settings.map;
        [Inject] private SerializationSettings _settings;

        public abstract void Queue(TContract contract);
    }
}