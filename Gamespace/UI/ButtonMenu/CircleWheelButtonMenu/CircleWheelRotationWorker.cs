using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelRotationWorker
    {
        public float circleRotation => _circleRotation;
        public float cursorRotation
        {
            get => _cursorRotation;
            set => _cursorRotation = value;
        }

        [Inject] private CircleWheelSettings _settings;
        [Inject] private CircleWheelMousePositionInputWorker _mousePositionInputWorker;

        private float _circleRotation;
        private float _cursorRotation;
        
        public void Rotate(Vector2 menuCenter)
        {
            menuCenter = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
            _settings.cursor.fillAmount = Mathf.Lerp(_settings.cursor.fillAmount, _settings.desiredFill, .2f);

            Vector3 screenBounds = new Vector3(menuCenter.x, menuCenter.y, 0f);
            Vector2 vector = _mousePositionInputWorker.position - screenBounds;

            if (_settings.tiltTowardMouse)
            {
                float x = vector.x / screenBounds.x, y = vector.y / screenBounds.y;
                _settings.panel.transform.localRotation = Quaternion.Slerp(_settings.panel.transform.localRotation, 
                    Quaternion.Euler((Vector3)(new Vector2(y, -x) * -_settings.tiltAmount) + Vector3.forward * _settings.zRotation), _settings.lerpAmount);
            }
            else
                _settings.panel.transform.localRotation = Quaternion.Euler(Vector3.forward * _settings.zRotation);

            _circleRotation = _settings.zRotation + 57.29578f * Mathf.Atan2(vector.x, vector.y);

            if (_circleRotation < 0f)
                _circleRotation += 360f;
            
            _cursorRotation = -(_circleRotation - _settings.cursor.fillAmount * 360f / 2f) + _settings.zRotation;
        }
    }
}