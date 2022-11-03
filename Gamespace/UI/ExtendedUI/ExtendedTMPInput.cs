using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamespace.UI
{
    public class ExtendedTMPInput : ExtendedUI
    {
#if UNITY_EDITOR
        [MenuItem("GameObject/UI/Extended UI/TMP Input Field")]
        public static void AddInputField()
        {
            Transform parent = null;
            if (Selection.activeGameObject != null)
                parent = Selection.activeGameObject.transform;
            
            GameObject obj = Instantiate(ExtendedPrefabProvider.LoadObject("Extended TMP InputField"), parent);
            Selection.activeGameObject = obj;
        }
#endif
        public string text
        {
            get { return _input.text; }
            set { _input.text = value; }
        }
        [SerializeField] private bool _holdOnNonEmpty;
        private TMP_InputField _input;
        protected override void Awake()
        {
            _input = GetComponent<TMP_InputField>();
            base.Awake();
        }
        void Start()
        {
            _input.onSelect.AddListener(s =>
            {
                _hoverBehaviour?.Behaviour?.On().Forget();
                
                if (!_holdOnNonEmpty || string.IsNullOrEmpty(_input.text)) 
                    _clickBehaviour?.Behaviour?.On().Forget();
            });
            _input.onDeselect.AddListener(s =>
            {
                _hoverBehaviour?.Behaviour?.Off().Forget();
                
                if (!_holdOnNonEmpty || string.IsNullOrEmpty(_input.text))
                    _clickBehaviour?.Behaviour?.Off().Forget();
            });
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            
        }
        public override void OnPointerUp(PointerEventData eventData)
        {

        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (Application.isMobilePlatform)
                return;
            
            if (_input.isFocused)
                return;
            
            base.OnPointerEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (Application.isMobilePlatform)
                return;
            
            if (_input.isFocused)
                return;
            
            base.OnPointerExit(eventData);
        }
    }
}