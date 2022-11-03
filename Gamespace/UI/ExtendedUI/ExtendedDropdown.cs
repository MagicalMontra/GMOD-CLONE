using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamespace.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamespace.UI
{
    public class ExtendedDropdown : ExtendedButton
    {
        public delegate void OnElementSelect();
        
#if UNITY_EDITOR
        [MenuItem("GameObject/UI/Extended UI/Extended Dropdown")]
        public static void AddDropDown()
        {
            Transform parent = null;
            if (Selection.activeGameObject != null)
                parent = Selection.activeGameObject.transform;
            
            GameObject obj = Instantiate(ExtendedPrefabProvider.LoadObject("Extended Dropdown"), parent);
            Selection.activeGameObject = obj;
        }
#endif
        
        public UnityEvent onElementSelected;

        public string value => _selectedData.value;

        public Color accentColor;

        [SerializeField] private UIAnimationFacade _expandBehaviour;

        [SerializeField] private LocalisedTextMeshProUGUI _localisedText;
        [SerializeField] private ExtendedDropData _selectedData;
        [SerializeField] private List<ExtendedDropData> _data = new List<ExtendedDropData>();
        [SerializeField] private ExtendedDropElement _templete;
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _dropPanel;

        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _title;

        private List<ExtendedDropElement> _dropElements = new List<ExtendedDropElement>();
        
        private bool _isMouseDown;
        private bool _isExpanded;
        private bool _isAnimating;

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < _data.Count; i++)
            {
                var newElement = Instantiate(_templete, _parent);
                newElement.Initialize(_data[i], accentColor);
                newElement.onClick.AddListener(() =>
                {
                    OnDataSelect(newElement.data);
                    onElementSelected?.Invoke();
                    SetDropPanel();
                });
                _dropElements.Add(newElement);
            }
        }

        private void Start()
        {
            if (_data.Count > 0)
            {
                OnDataSelect(_data[0]);
                _dropElements[0].SetMark(true);
            }
        }

        private async void SetDropPanel()
        {
            _isExpanded = !_isExpanded;

            if (_expandBehaviour == null)
            {
                _dropPanel.SetActive(_isExpanded);
                return;
            }

            if (_isExpanded)
            {
                _expandBehaviour?.Function.inStart.RemoveAllListeners();
                _expandBehaviour?.Function.inComplete.RemoveAllListeners();
                _expandBehaviour?.Function.inStart.AddListener(async () =>
                {
                    _isAnimating = true;
                    
                    await Task.Delay(50);
                    
                    _dropPanel.SetActive(_isExpanded);
                    
                    await Task.Delay(50);
                    
                    for (int i = 0; i < _dropElements.Count; i++)
                    {
                        _dropElements[i].OnExpand(_isExpanded);
                    }
                });
                _expandBehaviour?.Function.inComplete.AddListener(() =>
                {
                    _isAnimating = false;
                });

                _expandBehaviour?.Behaviour.On().Forget();


            }
            else
            {
                for (int i = 0; i < _dropElements.Count; i++)
                    _dropElements[i].OnExpand(_isExpanded);
                
                await Task.Delay(50);
                
                _expandBehaviour?.Function.outComplete.RemoveAllListeners();
                _expandBehaviour?.Function.outComplete.RemoveAllListeners();
                _expandBehaviour?.Function.outStart.AddListener(async () =>
                {
                    _isAnimating = true;
                });
                _expandBehaviour?.Function.outComplete.AddListener(() =>
                {
                    _isAnimating = false;
                    _dropPanel.SetActive(_isExpanded);
                });
                
                _expandBehaviour?.Behaviour?.Off().Forget();
            }

        }
        private void OnDataSelect(ExtendedDropData data)
        {
            _selectedData = data;
            _icon.sprite = data.icon;
            _localisedText.key = data.value;
            _localisedText.RequestTranslation();

            for (int i = 0; i < _dropElements.Count; i++)
            {
                if (_selectedData.value == _dropElements[i].data.value)
                {
                    _dropElements[i].SetMark(true);
                }
                else
                {
                    _dropElements[i].SetMark(false);
                }
            }
        }
        public void SetData(string value)
        {
            var data = _data.FirstOrDefault(l => l.value == value);
            OnDataSelect(data);
        }
        public override void OnPointerDown(PointerEventData eventData)
        {
            if (_isAnimating)
                return;
            
            base.OnPointerDown(eventData);
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (_isAnimating)
                return;

            base.OnPointerUp(eventData);
        }

        protected override void Press()
        {
            SetDropPanel();
        }

        protected override void Hover()
        {

        }
    }

    [Serializable]
    public struct ExtendedDropData
    {
        public Sprite icon;
        public string clusterTag;
        public string title;
        public string value;
    }
}