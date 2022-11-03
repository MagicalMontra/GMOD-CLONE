#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using Gamespace.Utilis;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [CustomEditor(typeof(PlaceableObjectCategory))]
    public class PlaceableObjectCategoryEditor : Editor
    {
        private bool _devMode;
        private bool _hasNewObject;
        private string _searchString;
        private GameObject _emptyPrefab;
        private Texture2D _missingIconTexture;
        private PlaceableObjectCategory _target;
        private void OnEnable()
        {
            _target = (PlaceableObjectCategory)target;
            //NOTE: Change this path if you change the folder hierarchy
            _missingIconTexture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Gamespace/Core/ObjectPlacing/Texture/NoIcon.png");
        }
        public override void OnInspectorGUI()
        {
            _devMode = EditorGUILayout.ToggleLeft("Debug", _devMode);

            if (_devMode)
            {
                base.OnInspectorGUI();
                return;
            }

            ScriptableObjectEditorHelper.DrawHeader($"{_target.catName} Placeable Object Category");
            EditorGUILayout.Space(1.5f);
            DrawScanButton();
            DrawUpdateIconButton();
            EditorGUILayout.Space(3);
            DrawSearchGroup();
        }
        private void DrawUpdateIconButton()
        {
            var updateIconButton = ScriptableObjectEditorHelper.DrawButton("Update objects icon");

            if (updateIconButton)
            {
                var catPath = AssetDatabase.GetAssetPath(_target);
                var dataPath = Application.dataPath.Replace("Assets", "");
                catPath = catPath.Replace(_target.name + ".asset", "");
                var directoryInfo = new DirectoryInfo(dataPath + catPath);
                var iconsFolderPath = catPath + "/Icons";

                if (!directoryInfo.Exists)
                {
                    EditorUtility.DisplayDialog("Error", "Unexpected error", "Ok");
                    return;
                }

                for (int i = 0; i < _target.count; i++)
                {
                    RuntimePreviewGenerator.MarkTextureNonReadable = false;
                    Color color = Color.clear;
                    // ColorUtility.TryParseHtmlString("#2E2E2E", out color);
                    RuntimePreviewGenerator.BackgroundColor = color;
                    RuntimePreviewGenerator.OrthographicMode = true;
                    RuntimePreviewGenerator.Padding = 5f;
                    Texture2D icon = RuntimePreviewGenerator.GenerateModelPreview(_target.GetObject(i).prefab.transform, 512, 512);

                    if (icon != null)
                    {
                        string iconPath = iconsFolderPath + "/" + _target.GetObject(i).name + "_icon" + ".png";
                        byte[] bytes = icon.EncodeToPNG();
                        File.WriteAllBytes(iconPath, bytes);
                        AssetDatabase.SaveAssets();

                        if (iconPath.StartsWith(Application.dataPath))
                            iconPath = "Assets" + iconPath.Substring(Application.dataPath.Length);

                        AssetDatabase.Refresh();
                        icon = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);
                        _target.GetObject(i).icon = icon;

                        if (icon == null)
                            _target.GetObject(i).icon = _missingIconTexture;
                        else
                        {
                            AssetDatabase.ImportAsset(iconPath);
                            var iconImporter = AssetImporter.GetAtPath(iconPath) as TextureImporter;

                            if (iconImporter != null)
                            {
                                iconImporter.textureType = TextureImporterType.Sprite;
                                AssetDatabase.WriteImportSettingsIfDirty(iconPath);
                            }
                        }
                        
                        EditorUtility.SetDirty(_target.GetObject(i).icon);
                        EditorUtility.SetDirty(_target);
                    }
                }
            }
        }
        private void DrawSearchGroup()
        {
            GUILayout.Label("Object Count: " + _target.count, EditorStyles.largeLabel);
            GUILayout.Label("Object search bar");
            _searchString = EditorGUILayout.TextField(_searchString, EditorStyles.toolbarSearchField);

            if (string.IsNullOrEmpty(_searchString))
                return;

            for (int i = 0; i < _target.count; i++)
            {
                if (!_target.GetObject(i).name.ToLower().Contains(_searchString))
                    continue;

                ScriptableObjectEditorHelper.DrawHeader(_target.GetObject(i).name);
                EditorGUILayout.BeginHorizontal("Box");
                EditorGUILayout.BeginVertical();
                EditorGUILayout.Space(3);
                var rect = GUILayoutUtility.GetLastRect();
                rect.x += 5f;
                rect.y += 5f;
                rect.size = new Vector2(64, 64);
                EditorGUI.DrawPreviewTexture(rect, _target.GetObject(i).icon);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical();
                GUILayout.Label("Prefab");
                _target.GetObject(i).prefab = (GameObject)EditorGUILayout.ObjectField(_target.GetObject(i).prefab, typeof(GameObject), false);

                if (GUI.changed)
                {
                    if (!string.Equals(_target.GetObject(i).name, _target.GetObject(i).prefab.name, StringComparison.Ordinal))
                    {
                        RuntimePreviewGenerator.MarkTextureNonReadable = false;
                        Color color = Color.clear;
                        // ColorUtility.TryParseHtmlString("#2E2E2E", out color);
                        RuntimePreviewGenerator.BackgroundColor = color;
                        RuntimePreviewGenerator.OrthographicMode = true;
                        RuntimePreviewGenerator.Padding = 5f;
                        _target.GetObject(i).name = _target.GetObject(i).prefab.name;
                        _target.GetObject(i).icon = RuntimePreviewGenerator.GenerateModelPreview(_target.GetObject(i).prefab.transform, 512, 512);
                        EditorUtility.SetDirty(_target.GetObject(i).icon);
                        EditorUtility.SetDirty(_target);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                }

                var removeFromDatabase = ScriptableObjectEditorHelper.DrawButton("Remove from database");

                if (removeFromDatabase)
                    _target.Remove(i);

                var removePermanent = ScriptableObjectEditorHelper.DrawButton("Remove permanently");

                if (removePermanent)
                {
                    var promt = EditorUtility.DisplayDialog("Are you sure?",
                        $"This action will remove {_target.GetObject(i).name} from project permanently, both its prefab and generated icon will be remove with this process.\n Continue?",
                        "Cancel", "Confirm");

                    if (!promt)
                    {
                        var iconPath = AssetDatabase.GetAssetPath(_target.GetObject(i).icon);
                        var prefabPath = AssetDatabase.GetAssetPath(_target.GetObject(i).prefab);
                        AssetDatabase.DeleteAsset(iconPath);
                        AssetDatabase.DeleteAsset(prefabPath);
                        _target.Remove(i);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        EditorUtility.SetDirty(_target);
                        return;
                    }
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
            }
        }
        private void DrawScanButton()
        {
            var scanButton = ScriptableObjectEditorHelper.DrawButton("Scan for new placeable object");

            if (scanButton)
            {
                var catPath = AssetDatabase.GetAssetPath(_target);
                var dataPath = Application.dataPath.Replace("Assets", "");
                catPath = catPath.Replace(_target.name + ".asset", "");
                var directoryInfo = new DirectoryInfo(dataPath + catPath);
                var iconsFolderPath = catPath + "/Icons";

                if (!directoryInfo.Exists)
                {
                    EditorUtility.DisplayDialog("Error", "Unexpected error", "Ok");
                    return;
                }

                var allObjectPath = directoryInfo.GetFiles("*.prefab", SearchOption.TopDirectoryOnly);

                for (int i = 0; i < allObjectPath.Length; i++)
                {
                    var prefabPath = allObjectPath[i].FullName;

                    prefabPath = prefabPath.Replace("\\", "/");

                    if (prefabPath.StartsWith(Application.dataPath))
                        prefabPath = "Assets" + prefabPath.Substring(Application.dataPath.Length);

                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

                    if (_target.IsExist(prefab.name))
                        continue;

                    var placeable = prefab.GetComponent<IPlaceableObject>();

                    if (placeable == null)
                        continue;

                    RuntimePreviewGenerator.MarkTextureNonReadable = false;
                    Color color = Color.clear;
                    // ColorUtility.TryParseHtmlString("#2E2E2E", out color);
                    RuntimePreviewGenerator.BackgroundColor = color;
                    RuntimePreviewGenerator.OrthographicMode = true;
                    RuntimePreviewGenerator.Padding = 5f;
                    Texture2D icon = RuntimePreviewGenerator.GenerateModelPreview(prefab.transform, 512, 512);

                    if (icon != null)
                    {
                        string iconPath = iconsFolderPath + "/" + prefab.name + "_icon" + ".png";
                        byte[] bytes = icon.EncodeToPNG();
                        File.WriteAllBytes(iconPath, bytes);
                        AssetDatabase.SaveAssets();

                        if (iconPath.StartsWith(Application.dataPath))
                            iconPath = "Assets" + iconPath.Substring(Application.dataPath.Length);

                        AssetDatabase.Refresh();
                        icon = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);

                        if (icon == null)
                            icon = _missingIconTexture;
                        else
                        {
                            AssetDatabase.ImportAsset(iconPath);
                            var iconImporter = AssetImporter.GetAtPath(iconPath) as TextureImporter;

                            if (iconImporter != null)
                            {
                                iconImporter.textureType = TextureImporterType.Sprite;
                                AssetDatabase.WriteImportSettingsIfDirty(iconPath);
                            }
                        }

                        _target.Add(prefab, icon);
                        
                        EditorUtility.SetDirty(_target.GetObject(i).icon);
                        EditorUtility.SetDirty(_target);
                    }
                }

                EditorUtility.SetDirty(_target);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}
#endif