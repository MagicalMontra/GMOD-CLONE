using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class SliderActionPropertyUIElement : ActionPropertyUIElement
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_InputField _inputField;

        public override void Setup(object instance, FieldInfo field)
        {
            _slider.onValueChanged.RemoveAllListeners();
            _inputField.onValueChanged.RemoveAllListeners();

            if (field.FieldType == typeof(int))
            {
                var value = (int)field.GetValue(instance);
                _slider.wholeNumbers = true;
                _slider.value = value;
                _inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
                _inputField.text = value.ToString();
                _inputField.onValueChanged.AddListener(outputValue =>
                {
                    int.TryParse(outputValue, out var result);
                    _slider.value = result;
                });
                _slider.onValueChanged.AddListener(outputValue =>
                {
                    var result = Mathf.CeilToInt(outputValue);
                    _inputField.text = result.ToString();
                    field.SetValue(instance, result);
                });
                return;
            }
            
            if (field.FieldType == typeof(float))
            {
                var value = (float)field.GetValue(instance);
                _slider.wholeNumbers = false;
                _slider.value = value;
                _inputField.contentType = TMP_InputField.ContentType.DecimalNumber;
                _inputField.text = value.ToString("F2");
                _inputField.onValueChanged.AddListener(outputValue =>
                {
                    float.TryParse(outputValue, out var result);
                    _slider.value = result;
                });
                _slider.onValueChanged.AddListener(outputValue =>
                {
                    _inputField.text = outputValue.ToString("F2");
                    field.SetValue(instance, outputValue);
                });
                return;
            }
        }
        public class Pool : MonoMemoryPool<object, FieldInfo, Transform, ActionPropertyUIElement>
        {
            protected override void Reinitialize(object instance, FieldInfo field, Transform parent, ActionPropertyUIElement element)
            {
                element.transform.SetParent(parent);
                element.Setup(instance, field);
            }
        }
    }
}