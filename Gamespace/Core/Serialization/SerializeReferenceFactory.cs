using Zenject;

namespace Gamespace.Core.Serialization
{
    public class SerializeReferenceFactory<TContract> : IFactory<string, TContract>
    {
        private DiContainer _container;
        private SerializableDatabase _database;
        
        public SerializeReferenceFactory(DiContainer container, SerializableDatabase database)
        {
            _container = container;
            _database = database;
        }
        public TContract Create(string id)
        {
            return _container.InstantiatePrefabForComponent<TContract>(_database.GetPrefab(id));
        }
    }
}