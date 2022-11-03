#if UNITY_EDITOR
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
using Enumerable = System.Linq.Enumerable;

namespace Gamespace.Localization
{
    [CustomEditor(typeof(LanguageSettings))]
    public class LanguageSettingsEditor : Editor
    {
        private List<string> _languageList = new List<string>();
        private LanguageSettings _settings;

        private string _languageSearch = "";
        private string _newClusterName;
        private string _clusterPath = "Assets/Gamespace/Localization/Data/Clusters";
        private int _selectedLanguage;
        private int _oldSelectedLanguage;
        
        private CultureInfo[] _cultureInfos;

        private void OnEnable()
        {
            _settings = (LanguageSettings) target;

            for (int i = 0; i < _settings.avaliableLanguages.Count; i++)
                _languageList.Add(_settings.avaliableLanguages[i].name);

            _cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            _selectedLanguage = _oldSelectedLanguage = _settings.avaliableLanguages.FindIndex(alang => alang.name == _settings.defaultLanguage.name);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Default Language", EditorStyles.largeLabel);
            _selectedLanguage = EditorGUILayout.Popup(_selectedLanguage, _languageList.ToArray());

            if (_selectedLanguage != _oldSelectedLanguage)
            {
                _oldSelectedLanguage = _selectedLanguage;
                _settings.defaultLanguage = _settings.avaliableLanguages[_selectedLanguage];
                Serializer();
            }
            
            EditorGUILayout.Space(5);
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("Clear Language"))
            {
                _settings.avaliableLanguages.Clear();
                Serializer();
            }
            
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Project Languages", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
            
            for (int i = 0; i < _settings.avaliableLanguages.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label(_settings.avaliableLanguages[i].name, EditorStyles.largeLabel);

                if (GUILayout.Button($"Remove {_settings.avaliableLanguages[i].name}"))
                {
                    _settings.avaliableLanguages.RemoveAt(i);
                    Serializer();
                }
                
                EditorGUILayout.EndHorizontal();
                _settings.avaliableLanguages[i].wordWrapDatabase = (TextAsset) EditorGUILayout.ObjectField(_settings.avaliableLanguages[i].wordWrapDatabase, typeof(TextAsset), false);
                
                if (GUI.changed)
                    Serializer();
            }

            GUILayout.Label("Add new language", EditorStyles.largeLabel);
            GUILayout.Label("Search for language", EditorStyles.largeLabel);
            _languageSearch = EditorGUILayout.TextField(_languageSearch);

            for (int i = 0; i < _cultureInfos.Length; i++)
            {
                if (_languageSearch.Length < 2)
                    continue;

                var existedLanguage = false;

                for (int j = 0; j < _settings.avaliableLanguages.Count; j++)
                {
                    if (_settings.avaliableLanguages[j].name == _cultureInfos[i].Name)
                    {
                        existedLanguage = true;
                        break;
                    }
                }
                
                if (existedLanguage)
                    continue;
                
                if (!_cultureInfos[i].Name.ToLower().Contains(_languageSearch) && !_cultureInfos[i].EnglishName.ToLower().Contains(_languageSearch))
                    continue;
                    
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label(_cultureInfos[i].EnglishName, EditorStyles.largeLabel);
                EditorGUILayout.EndHorizontal();
                
                if (GUILayout.Button($"Select {_cultureInfos[i].EnglishName}"))
                    AddLanguage(_cultureInfos[i].Name);
            }

            EditorGUILayout.Space(5);

            GUILayout.Label("Add new language", EditorStyles.largeLabel);
            
            EditorGUILayout.Space(5);

            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Clusters", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Create new cluster");
            EditorGUILayout.EndVertical();

            GUILayout.Label("New Cluster Name");
            _newClusterName = EditorGUILayout.TextField(_newClusterName);

            if (GUILayout.Button($"Add Cluster"))
            {
                var newCluster = CreateInstance<LanguageCluster>();
                newCluster.tag = _newClusterName;

                AssetDatabase.CreateFolder(_clusterPath, _newClusterName);

                for (int i = 0; i < _settings.avaliableLanguages.Count; i++)
                {
                    var newData = new LanguageData(_settings.avaliableLanguages[i].name);
                    newCluster.list.Add(newData);
                }

                for (int i = 0; i < newCluster.list.Count; i++)
                {
                    File.WriteAllText($"{_clusterPath}/{_newClusterName}/{newCluster.list[i].name}.json", "{}");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    
                    newCluster.list[i].textFile = AssetDatabase.LoadAssetAtPath<TextAsset>($"{_clusterPath}/{_newClusterName}/{newCluster.list[i].name}.json");
                    EditorUtility.SetDirty(newCluster.list[i].textFile);
                }

                AssetDatabase.CreateAsset(newCluster, $"{_clusterPath}/{_newClusterName}/{_newClusterName}.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                EditorUtility.SetDirty(newCluster);
                
                _settings.clusters.Add(newCluster);
                Serializer();
            }
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Cluster Management");
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical("Button");
            for (int i = 0; i < _settings.clusters.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label(_settings.clusters[i].tag, EditorStyles.largeLabel);

                _settings.clusters[i] = (LanguageCluster) EditorGUILayout.ObjectField(_settings.clusters[i], typeof(LanguageCluster));
                
                EditorGUILayout.EndHorizontal();

                if (GUILayout.Button($"Delete {_settings.clusters[i].tag}"))
                {
                    _settings.clusters.RemoveAt(i);
                }
            }
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndVertical();
        }

        private void AddLanguage(string newLanguage)
        {
            _settings.avaliableLanguages.Add(new Language(newLanguage));
        }

        private void Serializer()
        {
            EditorUtility.SetDirty(_settings);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif