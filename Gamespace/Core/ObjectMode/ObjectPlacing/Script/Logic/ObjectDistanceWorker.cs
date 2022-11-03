using System.Collections.Generic;
using DG.Tweening;
using Zenject;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectDistanceWorker
    {
        [Inject] private ObjectProvider _provider;

        public List<IPlaceableObject> GetInDistanceObjects(float distance)
        {
            return _provider.placeableObjects.FindAll(o => o.distanceFromPlayer <= distance);
        }
    }
}