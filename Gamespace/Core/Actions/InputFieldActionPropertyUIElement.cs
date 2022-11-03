using System.Reflection;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class InputFieldActionPropertyUIElement : ActionPropertyUIElement
    {
        [SerializeField] private TMP_InputField _inputField;
        public override void Setup(object instance, FieldInfo field)
        {
            _inputField.onValueChanged.RemoveAllListeners();

            if (field.FieldType == typeof(int))
            {
                var value = (int)field.GetValue(instance);
                _inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
                _inputField.text = value.ToString();
                _inputField.onValueChanged.AddListener(inputValue =>
                {
                    if (string.IsNullOrEmpty(inputValue))
                        return;
                    
                    int.TryParse(inputValue, out var result);
                    field.SetValue(instance, result);
                });
                return;
            }
            
            if (field.FieldType == typeof(float))
            {
                var value = (float)field.GetValue(instance);
                _inputField.contentType = TMP_InputField.ContentType.DecimalNumber;
                _inputField.text = value.ToString("F2");
                _inputField.onValueChanged.AddListener(inputValue =>
                {
                    if (string.IsNullOrEmpty(inputValue))
                        return;
                    
                    float.TryParse(inputValue, out var result);
                    field.SetValue(instance, result);
                });
                return;
            }
            
            if (field.FieldType == typeof(string))
            {
                var value = (string)field.GetValue(instance);
                _inputField.contentType = TMP_InputField.ContentType.Alphanumeric;
                _inputField.text = value;
                _inputField.onValueChanged.AddListener(inputValue => field.SetValue(instance, inputValue));
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