#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Gamespace.UI
{
    public class ExtendedToggle : ExtendedButton
    {
        public bool IsTick => _isTick;
        
        public UnityEvent OnToggled;
        public UnityEvent OnUntoggled;
        
#if UNITY_EDITOR
        [MenuItem("GameObject/UI/Extended UI/Toggle")]
        public static void AddToggle()
        {
            Transform parent = null;
            if (Selection.activeGameObject != null)
                parent = Selection.activeGameObject.transform;
            
            GameObject obj = Instantiate(ExtendedPrefabProvider.LoadObject("Extended Toggle"), parent);
            Selection.activeGameObject = obj;
        }
#endif
        [SerializeField] private UIAnimationFacade _toggleAnimation;

        [SerializeField] private bool _isTick;

        protected override void Awake()
        {
            base.Awake();

            _clickBehaviour?.Function?.inComplete.AddListener(() => _clickBehaviour?.Function?.Reset());
            _toggleAnimation?.Function?.inComplete.AddListener(() => _clickBehaviour?.Behaviour?.On().Forget());
            _toggleAnimation?.Function?.inStart.AddListener(() => OnToggled.Invoke());
            _toggleAnimation?.Function?.outComplete.AddListener(() => _clickBehaviour?.Behaviour?.On().Forget());
            _toggleAnimation?.Function?.outStart.AddListener(() => OnUntoggled.Invoke());
        }
        public void SetActive(bool enabled)
        {
            if (_isTick == enabled)
                return;
            
            _isTick = enabled;

            if (enabled)
                _toggleAnimation?.Behaviour?.On().Forget();
            else
                _toggleAnimation?.Behaviour?.Off().Forget();
        }
        protected override void Press()
        {
            base.Press();
            SetActive(!_isTick);
        }
        public override void OnPointerDown(PointerEventData eventData)
        {

        }

        public override void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}