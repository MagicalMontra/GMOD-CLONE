#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Gamespace.Utilis;
using UnityEditor;
using UnityEngine;

namespace Gamespace.UI
{
    [CustomEditor(typeof(WheelButtonDatabase))]
    public class WheelButtonDatabaseEditor : Editor
    {
        private bool _debugMode;
        private string _searchKeyword;
        private List<bool> _editNameButtons = new List<bool>();
        private List<string> _oldButtonNames = new List<string>();
        private WheelButtonDatabase _database;
        private WheelButtonData _newData;
        private void OnEnable()
        {
            _database = (WheelButtonDatabase) target;
            _editNameButtons.Clear();
            _newData = new WheelButtonData();

            for (int i = 0; i < _database.count; i++)
            {
                _editNameButtons.Add(false);
                _oldButtonNames.Add(_database.GetData(i).id);
            }

            _searchKeyword = "";
        }

        public override void OnInspectorGUI()
        {
            _debugMode = EditorGUILayout.ToggleLeft("Debug Mode", _debugMode);

            if (_debugMode)
            {
                base.OnInspectorGUI();
                return;
            }
            
            ScriptableObjectEditorHelper.DrawHeader("Wheel Button Database");
            ScriptableObjectEditorHelper.DrawSubHeader("Create Button");
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal("Button");
            GUILayout.Label("Button Name:");
            _newData.id = EditorGUILayout.TextField(_newData.id);
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal("Button");
            _newData.icon = (Sprite)EditorGUILayout.ObjectField("Icon", _newData.icon, typeof(Sprite), false);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal("Button");
            GUILayout.Label("Button Description");
            EditorGUILayout.EndHorizontal();
            _newData.desc = EditorGUILayout.TextArea(_newData.desc);
            _newData.unlock = EditorGUILayout.ToggleLeft("Is Unlock?", _newData.unlock);
            _newData.useCustomColor = EditorGUILayout.ToggleLeft("Custom Color?", _newData.useCustomColor);
            
            if (_newData.useCustomColor)
            {
                EditorGUILayout.BeginHorizontal("Button");
                GUILayout.Label("Custom Color");
                EditorGUILayout.EndHorizontal();
                _newData.color = EditorGUILayout.ColorField(_newData.color);
            }
            
            EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty(_newData.id) || string.IsNullOrEmpty(_newData.desc));
            var createButton = ScriptableObjectEditorHelper.DrawButton("Create");
            EditorGUI.EndDisabledGroup();

            if (createButton)
            {
                _database.Add(_newData);
                _editNameButtons.Add(false);
                _oldButtonNames.Add(_newData.id);
                _newData = new WheelButtonData();
                EditorUtility.SetDirty(_database);
            }
            
            EditorGUILayout.EndHorizontal();
            
            ScriptableObjectEditorHelper.DrawSubHeader("Buttons");
            GUILayout.Label("Search Box");
            _searchKeyword = EditorGUILayout.TextField(_searchKeyword);
            for (int i = 0; i < _database.count; i++)
            {
                if (_searchKeyword.Length < 3)
                    break;
                
                var data = _database.GetData(i);
                
                if (!data.id.ToLower().Contains(_searchKeyword) && !data.desc.ToLower().Contains(_searchKeyword))
                    continue;

                EditorGUILayout.BeginVertical("Box");
                EditorGUILayout.BeginHorizontal("Button");
                if (!_editNameButtons[i])
                    GUILayout.Label($"{_database.GetData(i).id} Button");
                else
                    _database.GetData(i).id = EditorGUILayout.TextField(_database.GetData(i).id);
                bool editButton;
                editButton = ScriptableObjectEditorHelper.DrawButton(!_editNameButtons[i] ? "Edit Button Name" : "Confirm Button Name");
                if (editButton)
                {
                    if (_editNameButtons[i])
                    {
                        var editPropmt = EditorUtility.DisplayDialog($"Are you sure to rename {data.id}", $"You need to rename every call of this key and rename them accordingly", "Cancel", "Ok");

                        if (editPropmt)
                        {
                            _editNameButtons[i] = false;
                            _database.GetData(i).id = _oldButtonNames[i];
                            EditorUtility.SetDirty(_database);
                        }
                        else
                            _editNameButtons[i] = false;
                    }
                    else
                        _editNameButtons[i] = !_editNameButtons[i];
                }
                
                var deleteButton = ScriptableObjectEditorHelper.DrawButton($"Delete");
                if (deleteButton)
                {
                    var deletePropmt = EditorUtility.DisplayDialog($"Are you sure to delete {data.id}", $"Every call with this key will not work", "Cancel", "Ok");

                    if (!deletePropmt)
                    {
                        _database.Remove(i);
                        _editNameButtons.RemoveAt(i);
                        _oldButtonNames.RemoveAt(i);
                        EditorUtility.SetDirty(_database);
                    }
                }

                EditorGUILayout.EndHorizontal();
                
                EditorGUILayout.BeginHorizontal("Box");
                EditorGUILayout.BeginVertical();
                EditorGUILayout.Space(3);
                var rect = GUILayoutUtility.GetLastRect();
                rect.x += 5f;
                rect.y += 30f;
                rect.size = new Vector2(64, 64);
                EditorGUI.DrawTextureTransparent(rect, data.icon.texture);
                data.icon = (Sprite)EditorGUILayout.ObjectField(data.icon, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical();
                
                EditorGUILayout.BeginHorizontal("Button");
                GUILayout.Label("Button Description");
                EditorGUILayout.EndHorizontal();
                data.desc = EditorGUILayout.TextArea(data.desc);
                data.unlock = EditorGUILayout.ToggleLeft("Is Unlock?", data.unlock);
                data.useCustomColor = EditorGUILayout.ToggleLeft("Custom Color?", data.useCustomColor);

                if (data.useCustomColor)
                {
                    EditorGUILayout.BeginHorizontal("Button");
                    GUILayout.Label("Custom Color");
                    EditorGUILayout.EndHorizontal();
                    data.color = EditorGUILayout.ColorField(data.color);
                }
                
                EditorUtility.SetDirty(_database);
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
        }
    }
}
#endif