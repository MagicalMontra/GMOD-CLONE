using System.Reflection;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public abstract class ActionPropertyUIElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        public abstract void Setup(object instance, FieldInfo field);
        public void SetName(string name)
        {
            _title.text = name;
        }
    }
}