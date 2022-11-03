using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    [AddComponentMenu("UI/Blur Panel")]
    public class BlurImage : Image
    {
        public bool animate;
        public bool createNew = false;
        public float time = 0.5f;
        public float delay = 0f;
        public float magnitude = 1f;

        private Color _startColor;
        private CanvasGroup _canvas;

        void Reset()
        {
            color = _startColor;
        }

        protected override void Awake()
        {
            if (createNew)
            {
                // var mat = new Material(Shader.Find("UI/GaussianBlur"));
                // mat.renderQueue = 3000;
                // material = mat;
            }

            _startColor = color;
            _canvas = GetComponent<CanvasGroup>();
            base.Awake();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            // if (Application.isPlaying)
            // {
            //     if (animate)
            //     {
            //         material.SetFloat("_Size", 0);
            //         _canvas.alpha = 0;
            //         DOVirtual.Float(0, magnitude, time, UpdateBlur).SetDelay(delay);
            //     }
            //     else
            //     {
            //         material.SetFloat("_Size", 1);
            //         _canvas.alpha = 1;
            //     }
            // }

        }

        void UpdateBlur(float value)
        {
            material.SetFloat("_Size", value);
            if (value < 1)
                _canvas.alpha = value;
            else
                _canvas.alpha = 1;
        }

        public void Deactivate(Action onComplete)
        {
            // DOVirtual.Float(magnitude, 0, time, UpdateBlur).OnComplete(() => onComplete?.Invoke());
        }
    }
}
