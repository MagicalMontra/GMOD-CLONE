using UnityEngine;
using Zenject;

namespace Gamespace.Utilis
{
    public class NonMonoDrawGizMoFactory : IFactory<NonMonoDrawGizmo>
    {
        private DiContainer _container;

        public NonMonoDrawGizMoFactory(DiContainer container)
        {
            _container = container;
        }
        public NonMonoDrawGizmo Create()
        {
            return _container.InstantiateComponentOnNewGameObject<NonMonoDrawGizmo>();
        }
    }
}