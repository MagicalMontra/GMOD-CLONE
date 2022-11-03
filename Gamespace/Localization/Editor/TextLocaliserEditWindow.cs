#if UNITY_EDITOR
using System.Collections.Generic;
using SimpleJSON;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Localization
{
    public class TextLocaliserEditWindow : EditorWindow
    {
        public static void Open(string key)
        {
            if (Application.isPlaying)
                return;
            
            TextLocaliserEditWindow window = CreateInstance<TextLocaliserEditWindow>();
            window.titleContent = new GUIContent("Localisation Window");
            window.ShowUtility();
            window.key = key;
        }

        public string clusterName;
        public string value;
        public string key;

        public void OnGUI()
        {
            if (Application.isPlaying)
                return;
            
            key = EditorGUILayout.TextField("Key :", key);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Value :", GUILayout.MaxWidth(50));

            EditorStyles.textArea.wordWrap = true;
            value = EditorGUILayout.TextArea(value, EditorStyles.textArea, GUILayout.Height(180), GUILayout.Width(400));
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Add"))
            {
                // if (LanguageEditorHandler.GetValue(clusterName, key) != key)
                // {
                //     LanguageEditorHandler.Replace(key, value);
                // }
                // else
                // {
                //     LanguageEditorHandler.Add(key, value);
                // }
            }

            minSize = new Vector2(460, 260);
            maxSize = minSize;

        }
    }

    public class TextLocaliserSearchWindow : EditorWindow
    {
        public static void Open(string clusterTag)
        {
            if (Application.isPlaying)
                return;
            
            _viewMode = true;
            TextLocaliserSearchWindow window = CreateInstance<TextLocaliserSearchWindow>();
            window.titleContent = new GUIContent("Localisation Search");
            
            _datas.Clear();
            var cluster = LanguageEditorHandler.GetCluster(clusterTag);
            var jsonObjects = new List<JSONObject>();

            for (int i = 0; i < cluster.list.Count; i++)
                jsonObjects.Add(LanguageEditorHandler.Parse(cluster.list[i].textFile));

            for (int i = 0; i < cluster.list.Count; i++)
            {
                foreach (var element in jsonObjects[i])
                {
                    var existedIndex = _datas.FindIndex(l => l.key == element.Key);

                    if (existedIndex == -1)
                    {
                        var addedElement = new LanguageKeyPair(element.Key);
                        addedElement.AddValue(element.Value);
                        _datas.Add(addedElement);
                    }
                    else
                        _datas[existedIndex].AddValue(element.Value);
                }
            }

            
            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect r = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(r, new Vector2(500, 300));
        }
        public static void Open(LocalisedTextMeshProUGUI localisedTextMesh)
        {
            if (Application.isPlaying)
                return;
            
            _localisedTextMesh = localisedTextMesh;
            TextLocaliserSearchWindow window = CreateInstance<TextLocaliserSearchWindow>();
            window.titleContent = new GUIContent("Localisation Search");

            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect r = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(r, new Vector2(500, 300));
        }

        public static void Open(LocalisedString localisedString)
        {
            if (Application.isPlaying)
                return;
            
            _localisedString = localisedString;
            TextLocaliserSearchWindow window = CreateInstance<TextLocaliserSearchWindow>();
            window.titleContent = new GUIContent("Localisation Search");
            
            _datas.Clear();
            var cluster = LanguageEditorHandler.GetCluster(localisedString.clusterTag);
            var jsonObjects = new List<JSONObject>();

            for (int i = 0; i < cluster.list.Count; i++)
                jsonObjects.Add(LanguageEditorHandler.Parse(cluster.list[i].textFile));

            for (int i = 0; i < cluster.list.Count; i++)
            {
                foreach (var element in jsonObjects[i])
                {
                    var existedIndex = _datas.FindIndex(l => l.key == element.Key);

                    if (existedIndex == -1)
                    {
                        var addedElement = new LanguageKeyPair(element.Key);
                        addedElement.AddValue(element.Value);
                        _datas.Add(addedElement);
                    }
                    else
                        _datas[existedIndex].AddValue(element.Value);
                }
            }

            
            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect r = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(r, new Vector2(500, 300));
        }

        private static LocalisedTextMeshProUGUI _localisedTextMesh;
        private static LocalisedString _localisedString;

        private static List<LanguageKeyPair> _datas = new List<LanguageKeyPair>();
        private Vector2 _scrollValue;
        private string _value;
        private bool _isValueMatch;
        private static bool _viewMode;

        public void OnGUI()
        {
            if (Application.isPlaying)
                return;
            
            EditorGUILayout.BeginHorizontal("Box");
            EditorGUILayout.LabelField("Search: ", EditorStyles.boldLabel);
            _value = EditorGUILayout.TextField(_value);
            EditorGUILayout.EndHorizontal();

            GetSearchResult();
        }

        private void GetSearchResult()
        {
            if (string.IsNullOrEmpty(_value))
                return;

            EditorGUILayout.BeginVertical();
            _scrollValue = EditorGUILayout.BeginScrollView(_scrollValue);

            for (int i = 0; i < _datas.Count; i++)
            {
                for (int j = 0; j < _datas[i].values.Count; j++)
                {
                    _isValueMatch = _datas[i].values[j] == _value;
                }
                
                if (_datas[i].key.ToLower().Contains(_value.ToLower()) || _isValueMatch)
                {
                    EditorGUILayout.BeginHorizontal("Box");

                    var select = new GUIContent(EditorGUIUtility.IconContent("d_FilterSelectedOnly"));

                    if (_viewMode)
                    {
                        if (GUILayout.Button(select, GUILayout.MaxHeight(20), GUILayout.MaxWidth(20)))
                        {
                            EditorGUIUtility.systemCopyBuffer = _datas[i].key;
                            Close();
                        }
                    }
                    else
                    {
                        if (GUILayout.Button(select, GUILayout.MaxHeight(20), GUILayout.MaxWidth(20)))
                        {
                            _localisedString.key = _datas[i].key;
                            Close();
                        }
                        var delete = new GUIContent(EditorGUIUtility.IconContent("d_TreeEditor.Trash"));

                        if (GUILayout.Button(delete, GUILayout.MaxHeight(20), GUILayout.MaxWidth(20)))
                        {
                            if (EditorUtility.DisplayDialog("Remove Key " + _datas[i].key + "?", "This will remove the element from localisation, are you sure?", "I understand, proceed", "Missed clicked, eject eject!"))
                            {
                                var cluster = LanguageEditorHandler.GetCluster(_localisedString.clusterTag);

                                for (int j = 0; j < cluster.list.Count; j++)
                                    LanguageEditorHandler.Remove(cluster.list[j].textFile, LanguageEditorHandler.Parse(cluster.list[j].textFile), _datas[i].key);

                            }
                        }
                    }

                    EditorGUILayout.SelectableLabel(_datas[i].key, EditorStyles.textField);
                    for (int j = 0; j < _datas[i].values.Count; j++)
                        EditorGUILayout.SelectableLabel(_datas[i].values[j], EditorStyles.textArea);
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}
#endif