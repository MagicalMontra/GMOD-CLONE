using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.UI
{
    public class ExtendedWheelButton : MonoBehaviour
    {
        public string id => _data.id;
        public string desc => _data.desc;
        public bool isUnlock => _data.unlock;
        public bool useCustomColor => _data.useCustomColor;
        public float degree => _degree;
        public Color customColor => _data.color;
        public Color currentColor => _image.color;
        public Sprite icon => _data.icon;
        public UnityEvent onClick;
        
        [SerializeField] private Image _image;
        [SerializeField] private WheelButtonData _data;

        private float _degree;

        public void Initialize(SegmentData segmentData)
        {
            _degree = segmentData.degree;
            transform.localScale = segmentData.scale;
            transform.localPosition = segmentData.position;
        }
        public void Setup(Action action, WheelButtonData data)
        {
            _data.Clone(data);
            _image.sprite = data.icon;
            onClick.RemoveAllListeners();
            onClick.AddListener(action.Invoke);
        }
        public void SetColor(Color color)
        {
            _image.color = color;
        }
        private void Reset(Quaternion rotation, Transform parent)
        {
            transform.position = Vector3.zero;
            transform.rotation = rotation;
            transform.SetParent(parent);
        }
        public class Pool : MonoMemoryPool<Quaternion, Transform, ExtendedWheelButton>
        {
            protected override void Reinitialize(Quaternion rotation, Transform parent, ExtendedWheelButton segment)
            {
                segment.Reset(rotation, parent);
            }
        }
    }
}