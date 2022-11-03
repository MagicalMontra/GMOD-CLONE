using Zenject;
using UnityEngine;
using Gamespace.Core.ObjectMode.PlaceableSurface;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlacingPositionValidator
    {
        public int selectedSurfaceIndex = -1;
        
        [Inject] private ISurfaceSelectionWorker _surfaceSelection;
        [Inject] private PlacingRaycastSettings _raycastSettings;
        
        private PlacingData _data;

        public PlacingData Validate(IPlaceableSurface[] surfaces)
        {
            if (_data is null)
                _data = new PlacingData();
            
            Ray ray = _raycastSettings.mainCamera.ViewportPointToRay(Vector3.one * 0.5f);
            var noneHitPosition = ray.origin + (ray.direction * _raycastSettings.floatingDistance);
            var lookEuler = Quaternion.LookRotation(-ray.direction).eulerAngles;
            lookEuler.x += 86f;

            RaycastHit hit;
            var selectingSurfaceIndex = _surfaceSelection.Select(surfaces, ray);

            if (Physics.Raycast(ray, out hit, _raycastSettings.floatingDistance, _raycastSettings.castingMask))
            {
                selectedSurfaceIndex = selectingSurfaceIndex;
                _data.Set(hit.point, hit.transform.eulerAngles, hit.transform.up);
                return _data;
            }

            if (selectingSurfaceIndex > -1)
            {
                ray = new Ray(noneHitPosition, -surfaces[selectingSurfaceIndex].transform.up);

                if (Physics.Raycast(ray, out hit, _raycastSettings.inDirectDistance, _raycastSettings.castingMask))
                {
                    selectedSurfaceIndex = selectingSurfaceIndex;
                    _data.Set(hit.point, hit.transform.eulerAngles, hit.transform.up);
                    return _data;
                }
            }

            _data.Set(false , noneHitPosition);
            return _data;
        }
    }
}