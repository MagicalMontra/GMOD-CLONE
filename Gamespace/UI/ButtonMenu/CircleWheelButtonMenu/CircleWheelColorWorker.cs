using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelColorWorker
    {
        [Inject] private CircleWheelSettings _settings;
        [Inject] private CircleWheelButtonWorker _buttonWorker;
        [Inject] private CircleWheelRotationWorker _rotationWorker;
        
        public ExtendedWheelButton Handle(Vector2 menuCenter, ExtendedWheelButton selectButton)
        {
            float mouseDistanceFromCenter = Vector2.Distance(menuCenter, Input.mousePosition);
            if (_settings.needHovering && (mouseDistanceFromCenter > _settings.pieThickness) || !_settings.needHovering)
            {
                _settings.cursor.enabled = true;

                float difference = float.MaxValue;
                ExtendedWheelButton nearest = null;
                for (int i = 0; i < _buttonWorker.count; i++)
                {
                    ExtendedWheelButton buttonObject = _buttonWorker.GetButton(i);
                    buttonObject.transform.localScale = Vector3.one;
                    float rotation = buttonObject.degree;
                    if (Mathf.Abs(rotation - _rotationWorker.circleRotation) < difference)
                    {
                        nearest = buttonObject;
                        difference = Mathf.Abs(rotation - _rotationWorker.circleRotation);
                    }

                    if (_settings.rotateButton)
                        buttonObject.transform.localEulerAngles = new Vector3(0, 0, -_settings.zRotation);
                }

                selectButton = nearest;

                if (_settings.snap) 
                    _rotationWorker.cursorRotation = -(selectButton.degree - _settings.cursor.fillAmount * 360f / 2f);
                
                _settings.cursor.transform.localRotation = Quaternion.Slerp(_settings.cursor.transform.localRotation, Quaternion.Euler(0, 0, _rotationWorker.cursorRotation), _settings.lerpAmount);
                selectButton.SetColor(Color.Lerp(selectButton.currentColor, _settings.backgroundColor, _settings.lerpAmount));

                for (int i = 0; i < _buttonWorker.count; i++)
                {
                    ExtendedWheelButton button = _buttonWorker.GetButton(i);
                    if (button != selectButton)
                    {
                        if (button.isUnlock)
                            button.SetColor(Color.Lerp(button.currentColor, button.useCustomColor ? button.customColor : _settings.accentColor, _settings.lerpAmount));
                        else
                            button.SetColor(Color.Lerp(button.currentColor, _settings.disabledColor, _settings.lerpAmount));
                    }
                }

                try
                {
                    if (selectButton && selectButton.isUnlock)
                    {
                        _settings.cursor.color = Color.Lerp(_settings.cursor.color, selectButton.useCustomColor ? selectButton.customColor : _settings.accentColor, _settings.lerpAmount);
                    }
                    else
                        _settings.cursor.color = Color.Lerp(_settings.cursor.color, _settings.disabledColor, _settings.lerpAmount);
                }
                catch
                {
                }
            }
            else if (_settings.cursor.enabled && selectButton != null)
            {
                _settings.cursor.enabled = false;
                if (selectButton.isUnlock)
                    selectButton.SetColor(selectButton.useCustomColor ? selectButton.customColor : _settings.accentColor);
                else
                    selectButton.SetColor(_settings.disabledColor);

                for (int i = 0; i < _buttonWorker.count; i++)
                {
                    ExtendedWheelButton button = _buttonWorker.GetButton(i);
                    if (button != selectButton)
                    {
                        if (button.isUnlock)
                            button.SetColor(button.useCustomColor ? button.customColor : _settings.accentColor);
                        else
                            button.SetColor(_settings.disabledColor);
                    }
                }
            }

            return selectButton;
        }
    }
}