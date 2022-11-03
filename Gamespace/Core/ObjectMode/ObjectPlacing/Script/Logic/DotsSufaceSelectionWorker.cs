using System;
using Zenject;
using UnityEngine;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Placing
{ 
    public class DotsSufaceSelectionWorker : ISurfaceSelectionWorker
    {
        [Inject] private ILookSelectionWorker _lookSelectionWorker;
        [Inject] private PlacingRaycastSettings _raycastSettings;
        
        public int Select(IPlaceableSurface[] surfaces, Ray ray)
        {
            var closetLook = 0f;
            var distFromPlayer = Single.PositiveInfinity;
            var selectIndex = -1;

            for (int i = 0; i < surfaces.Length; i++)
            {
                var vector1 = ray.direction;
                var vector2 = surfaces[i].transform.position - ray.origin;
                surfaces[i].lookPercentage = _lookSelectionWorker.Calculate(vector1, vector2);
                surfaces[i].distanceFromPlayer = Vector3.Distance(_raycastSettings.mainCamera.transform.position, surfaces[i].transform.position);

                var isClosetLook = surfaces[i].lookPercentage > closetLook && surfaces[i].distanceFromPlayer < distFromPlayer;
                var isPassedThreshold = surfaces[i].lookPercentage > surfaces[i].lookThreshold;
                
                if (isClosetLook && isPassedThreshold)
                {
                    distFromPlayer = surfaces[i].distanceFromPlayer;
                    closetLook = surfaces[i].lookPercentage;
                    selectIndex = i;
                }
            }

            return selectIndex;
        }
    }
}