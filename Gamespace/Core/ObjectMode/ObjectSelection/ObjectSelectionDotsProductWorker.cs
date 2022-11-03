using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Selection
{
    public class ObjectSelectionDotsProductWorker : IObjectSelectionWorker
    {
        [Inject] private ObjectSelectionSettings _settings;
        [Inject] private ILookSelectionWorker _lookSelectionWorker;
        
        public int Select(List<IPlaceableObject> placeableObjects, Ray ray)
        {
            var closetLook = 0f;
            var distFromPlayer = Single.PositiveInfinity;
            var selectIndex = -1;

            for (int i = 0; i < placeableObjects.Count; i++)
            {
  
                var vector1 = ray.direction;
                var vector2 = placeableObjects[i].position - ray.origin;
                placeableObjects[i].lookPercentage = _lookSelectionWorker.Calculate(vector1, vector2);
                placeableObjects[i].distanceFromPlayer = Vector3.Distance(_settings.mainCamera.transform.position, placeableObjects[i].position);

                var isClosetLook = placeableObjects[i].lookPercentage > closetLook && placeableObjects[i].distanceFromPlayer < distFromPlayer;
                var isPassedThreshold = placeableObjects[i].lookPercentage > 0.95f;
                
                if (isClosetLook && isPassedThreshold)
                {
                    distFromPlayer = placeableObjects[i].distanceFromPlayer;
                    closetLook = placeableObjects[i].lookPercentage;
                    selectIndex = i;
                }
            }

            return selectIndex;
        }
    }
}