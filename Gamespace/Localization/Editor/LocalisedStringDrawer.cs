#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using Gamespace.Utilis;
using SimpleJSON;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Gamespace.Localization
{
    [CustomPropertyDrawer(typeof(LocalisedString), true)]
    public class LocalisedStringDrawer : PropertyDrawer
    {
        private LocalisedString _object;
        private LanguageCluster _cluster;
        private List<LanguageKeyPair> _listObjects = new List<LanguageKeyPair>();
        private List<JSONObject> _jsonObjects = new List<JSONObject>();
        private List<string> _clusters = new List<string>();
        private int _selectedIndex;
        private int _oldSelectedIndex;
        private float _height;
        private bool _isInitialized;
        private bool _isKeyPresent;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 170;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Application.isPlaying)
            {
                OnPlayMode(position, property, label);
                return;
            }
            
            InitializeEditorParameters(property);
            OnEditor(position, property, label);
        }
        private void InitializeEditorParameters(SerializedProperty property)
        {
            if (_isInitialized)
                return;
            
            _listObjects.Clear();
            _jsonObjects.Clear();
            _clusters.Clear();
            
            _object = PropertyDrawerUtility.GetTargetObjectOfProperty(property) as LocalisedString;
            var clusters = LanguageEditorHandler.GetClusters();
            for (int i = 0; i < clusters.Count; i++)
                _clusters.Add(clusters[i].tag);

            var clusterTag = property.FindPropertyRelative("clusterTag");

            if (!string.IsNullOrEmpty(clusterTag.stringValue))
            {
                _selectedIndex = _oldSelectedIndex = _clusters.FindIndex(c => c == clusterTag.stringValue);
                _cluster = LanguageEditorHandler.GetCluster(clusterTag.stringValue);

                for (int i = 0; i < _cluster.list.Count; i++)
                    _jsonObjects.Add(LanguageEditorHandler.Parse(_cluster.list[i].textFile));

                for (int i = 0; i < _cluster.list.Count; i++)
                {
                    foreach (var element in _jsonObjects[i])
                    {
                        var existedIndex = _listObjects.FindIndex(l => l.key == element.Key);

                        if (existedIndex == -1)
                        {
                            var addedElement = new LanguageKeyPair(element.Key);
                            addedElement.AddValue(element.Value);
                            _listObjects.Add(addedElement);
                        }
                        else
                            _listObjects[existedIndex].AddValue(element.Value);
                    }
                }

                if (_selectedIndex == -1)
                {
                    _selectedIndex = _oldSelectedIndex = 0;
                    clusterTag.stringValue = _clusters[0];
                }
            }
            else
            {
                if (_clusters.Count > 0)
                    clusterTag.stringValue = _clusters[0];
            }

            _isInitialized = true;
        }

        void OnPlayMode(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.LabelField(position, "Cluster", EditorStyles.largeLabel);
            position.y += 20;
            EditorGUI.LabelField(position, property.FindPropertyRelative("clusterTag").stringValue, EditorStyles.largeLabel);
            position.y += 20;
            EditorGUI.LabelField(position, "Key", EditorStyles.largeLabel);
            position.y += 20;
            EditorGUI.LabelField(position,property.FindPropertyRelative("key").stringValue, EditorStyles.largeLabel);
            EditorGUI.EndProperty();
        }

        void OnEditor(Rect position, SerializedProperty property, GUIContent label)
        {
            // var clusterTag = property.FindPropertyRelative("clusterTag");
            // var key = property.FindPropertyRelative("key");

            EditorGUI.BeginProperty(position, label, property);
            position.height = 18;
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.LabelField(position, "Cluster", EditorStyles.largeLabel);

            position.y += 20;
            _selectedIndex = EditorGUI.Popup(position, _selectedIndex, _clusters.ToArray(), EditorStyles.toolbarPopup);
            
            if (_selectedIndex != _oldSelectedIndex)
            {
                _object.clusterTag = _clusters[_selectedIndex];
                property.serializedObject.ApplyModifiedProperties();
                _oldSelectedIndex = _selectedIndex;
            }
            
            position.y += 30;
            EditorGUI.LabelField(position, "Key and value management", EditorStyles.largeLabel);

            if (!string.IsNullOrEmpty(_object.key))
            {
                position.y += 20;
                EditorGUI.LabelField(position, $"Key: {_object.key}");

                var index = _listObjects.FindIndex(pair => pair.key == _object.key);

                if (index <= -1)
                {
                    _isInitialized = false;
                    InitializeEditorParameters(property);
                    index = _listObjects.FindIndex(pair => pair.key == _object.key);
                }
                
                for (int i = 0; i < _listObjects[index].values.Count; i++)
                {
                    position.y += 20;
                    EditorGUI.LabelField(position, $"{_cluster.list[i].name} value: {_listObjects[index].values[i]}");
                }

                var textMesh = Selection.activeGameObject.GetComponent<LocalisedTextMeshProUGUI>();

                if (!_isKeyPresent)
                {
                    if (!ReferenceEquals(textMesh, null))
                    {
                        EditorUtility.SetDirty(textMesh);
                        PrefabUtility.RecordPrefabInstancePropertyModifications(textMesh);
                        Undo.RecordObject(textMesh, "On Key present");
                    }

                    EditorSceneManager.MarkSceneDirty(Selection.activeGameObject.scene);
                    _isKeyPresent = true;
                }
                
            }

            var search = new GUIContent(EditorGUIUtility.IconContent("Search Icon"));
            position.y += 20;
            position.x += 15;
            position.width -= 30;
            if (EditorGUI.DropdownButton(position, search, FocusType.Passive, EditorStyles.miniButtonMid))
            {
                TextLocaliserSearchWindow.Open(_object);
            }

            EditorGUI.EndProperty();
        }
    }
}
#endif