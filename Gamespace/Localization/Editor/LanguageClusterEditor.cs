#if UNITY_EDITOR
using SimpleJSON;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gamespace.Localization
{
    [CustomEditor(typeof(LanguageCluster))]
    public class LanguageClusterEditor : Editor
    {
        private LanguageCluster _cluster;
        private List<JSONObject> _jsonObjects = new List<JSONObject>();
        private List<string> _newValue = new List<string>();
        private List<bool> _editKeyCount = new List<bool>();
        private List<LanguageKeyPair> _listObjects = new List<LanguageKeyPair>();

        private string _searchString;
        private string _newKey;

        private void OnEnable()
        {
            _cluster = (LanguageCluster) target;
            RefreshData();
        }

        private void RefreshData()
        {
            _jsonObjects.Clear();
            _newValue.Clear();
            _editKeyCount.Clear();
            _listObjects.Clear();

            for (int i = 0; i < _cluster.list.Count; i++)
            {
                _jsonObjects.Add(LanguageEditorHandler.Parse(_cluster.list[i].textFile));
                _newValue.Add("");
            }

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
                    
                    _editKeyCount.Add(false);
                }
            }
        }

        public override void OnInspectorGUI()
        {
            DrawTitleHeader();
            DrawAddSection();
            EditorGUILayout.Space(10);
            DrawSearchSection();
        }

        private void DrawTitleHeader()
        {
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label($"Cluster Name: {_cluster.tag}", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
        }

        private void DrawAddSection()
        {
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label($"Add new key", EditorStyles.largeLabel);

            GUILayout.Label("Key name", EditorStyles.largeLabel);
            _newKey = EditorGUILayout.TextField(_newKey, EditorStyles.toolbarTextField);
            for (int i = 0; i < _cluster.list.Count; i++)
            {
                GUILayout.Label($"{_cluster.list[i].name} translation", EditorStyles.largeLabel);
                _newValue[i] = EditorGUILayout.TextArea(_newValue[i]);
            }

            EditorGUILayout.Space(5);
            if (GUILayout.Button("Add localize value", EditorStyles.toolbarButton))
            {
                for (int i = 0; i < _jsonObjects.Count; i++)
                {
                    _jsonObjects[i].Add(_newKey, _newValue[i]);
                    LanguageEditorHandler.Add(_cluster.list[i].textFile, _jsonObjects[i], _newKey, _newValue[i]);
                }

                _newKey = "";

                for (int i = 0; i < _newValue.Count; i++)
                    _newValue[i] = "";

                RefreshData();
            }

            EditorGUILayout.Space(5);
            EditorGUILayout.EndVertical();
        }

        private void DrawSearchSection()
        {
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Search for keys", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
            _searchString = EditorGUILayout.TextField(_searchString, EditorStyles.toolbarSearchField);

            if (!string.IsNullOrEmpty(_searchString))
            {
                for (int i = 0; i < _listObjects.Count; i++)
                {
                    var obj = _listObjects[i];
                    var matchValue = false;

                    for (int j = 0; j < obj.values.Count; j++)
                    {
                        if (obj.values[j].ToLower().Contains(_searchString))
                            matchValue = true;
                    }

                    if (obj.key.ToLower().Contains(_searchString) || matchValue)
                    {
                        EditorGUILayout.BeginVertical("Button");
                        EditorGUILayout.BeginHorizontal("Box");

                        if (!_editKeyCount[i])
                            GUILayout.Label(obj.key);
                        else
                            obj.key = EditorGUILayout.TextField(obj.key);

                        if (GUILayout.Button($"Edit this key"))
                        {
                            _editKeyCount[i] = !_editKeyCount[i];
                        }

                        if (GUILayout.Button($"Delete this key"))
                        {
                            var prompt = EditorUtility.DisplayDialog($"You're deleting {obj.key} key, Confirm?", "",
                                "Cancel", "Confirm");

                            if (!prompt)
                            {
                                for (int j = 0; j < _jsonObjects.Count; j++)
                                {
                                    LanguageEditorHandler.Remove(_cluster.list[j].textFile, _jsonObjects[j], obj.key);
                                }

                                RefreshData();
                                break;
                            }
                        }

                        EditorGUILayout.EndHorizontal();

                        for (int j = 0; j < obj.values.Count; j++)
                        {
                            GUILayout.Label(_cluster.list[j].name);
                            obj.values[j] = EditorGUILayout.TextArea(obj.values[j]);
                        }

                        if (GUILayout.Button($"Save {obj.key} key"))
                        {
                            for (int j = 0; j < _jsonObjects.Count; j++)
                            {
                                if (_jsonObjects[j].HasKey(obj.key))
                                    LanguageEditorHandler.Replace(_cluster.list[j].textFile, _jsonObjects[j], obj.key,
                                        obj.values[j]);
                                else
                                    LanguageEditorHandler.Add(_cluster.list[j].textFile, _jsonObjects[j], obj.key,
                                        obj.values[j]);
                            }

                            RefreshData();
                            break;
                        }

                        EditorGUILayout.Space(5);
                        EditorGUILayout.EndVertical();
                    }
                }
            }
            else
                EditorGUILayout.HelpBox("Search for key or value before proceed", MessageType.Info);
        }
    }
}
#endif