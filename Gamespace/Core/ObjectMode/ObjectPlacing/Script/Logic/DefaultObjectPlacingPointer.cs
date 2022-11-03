using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class DefaultObjectPlacingPointer : IObjectPlacingPointer
    {
        [Inject] private ObjectPlacingPointerSettings _pointerSettings;

        public void SetPointer(PlacingData data)
        {
            Set3DPointer(data.isEnabled, data.position, data.normal);
            SetDisablePointer(!data.isEnabled);
        }
        public void SetDisable()
        {
            _pointerSettings.placingPointer.SetActive(false);
            _pointerSettings.disablePointer.SetActive(false);
        }
        private void Set3DPointer(bool isEnabled, Vector3 position, Vector3 normal)
        {
            _pointerSettings.placingPointer.SetActive(isEnabled);
            
            if (!isEnabled)
                return;
            
            _pointerSettings.placingPointer.transform.position = position;
            _pointerSettings.placingPointer.transform.rotation = Quaternion.Euler(normal);
        }
        private void SetDisablePointer(bool isEnabled)
        {
            _pointerSettings.disablePointer.SetActive(isEnabled);
        }
    }
}