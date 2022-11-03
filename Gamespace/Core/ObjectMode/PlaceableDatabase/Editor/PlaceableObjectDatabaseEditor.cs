#if UNITY_EDITOR
using System;
using System.IO;
using Gamespace.Utilis;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Placing
{
    [CustomEditor(typeof(PlaceableObjectDatabase))]
    public class PlaceableObjectDatabaseEditor : Editor
    {
        private Texture2D _missingIconTexture;
        private PlaceableObjectDatabase _target;
        private void OnEnable()
        {
            _target = (PlaceableObjectDatabase)target;

            //NOTE: Change this path if you change the folder hierarchy
            _missingIconTexture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Gamespace/Core/ObjectPlacing/Texture/NoIcon.png");
        }
        public override void OnInspectorGUI()
        {
            ScriptableObjectEditorHelper.DrawHeader("Placeable Object Database");
            var selectFolderButton = ScriptableObjectEditorHelper.DrawButton("Create category from folder");

            if (selectFolderButton)
                CreateCategory();

            EditorGUILayout.Space(5);
            ScriptableObjectEditorHelper.DrawHeader("Catergories");
            var addCatergoryButton = ScriptableObjectEditorHelper.DrawButton("Add existed category");

            if (addCatergoryButton)
                AddCategory();

            EditorGUILayout.Space(3);

            for (int i = 0; i < _target.count; i++)
            {
                EditorGUILayout.ObjectField(_target.GetCategory(i), typeof(PlaceableObjectCategory), false);

                var removeCatergory = ScriptableObjectEditorHelper.DrawButton($"Remove {_target.GetCategory(i).catName} category");

                if (removeCatergory)
                    _target.Remove(i);
            }

            EditorGUILayout.Space(3);

            var clearCategoryButton = ScriptableObjectEditorHelper.DrawButton("Clear category");

            if (clearCategoryButton)
                ClearCatgory();
        }
        private void AddCategory()
        {
            var targetPath = EditorUtility.OpenFilePanel("Target Category", "", "asset");

            if (string.IsNullOrEmpty(targetPath))
                return;

            if (targetPath.StartsWith(Application.dataPath))
                targetPath = "Assets" + targetPath.Substring(Application.dataPath.Length);

            var newCategory = AssetDatabase.LoadAssetAtPath<PlaceableObjectCategory>(targetPath);

            if (newCategory == null)
            {
                EditorUtility.DisplayDialog("Error", "Selected asset is not a placeable object category", "Ok");
                return;
            }

            _target.Add(newCategory);
            EditorUtility.SetDirty(_target);
        }

        private void ClearCatgory()
        {
            _target.Clear();
        }
        private void CreateCategory()
        {
            var targetPath = EditorUtility.OpenFolderPanel("Target Folder", "Asset", "");

            if (string.IsNullOrEmpty(targetPath))
                return;

            if (targetPath.StartsWith(Application.dataPath))
            {
                targetPath = "Assets" + targetPath.Substring(Application.dataPath.Length);
            }

            var newCategory = CreateInstance<PlaceableObjectCategory>();
            var alreadyHasFolder = AssetDatabase.IsValidFolder(targetPath + "/Icons");

            if (!alreadyHasFolder)
                AssetDatabase.CreateFolder(targetPath, "Icons");

            string iconsFolderPath = targetPath + "/Icons";
            var dataPath = Application.dataPath.Replace("Assets", "");
            var directoryInfo = new DirectoryInfo(dataPath + targetPath);

            if (!directoryInfo.Exists)
            {
                EditorUtility.DisplayDialog("Error", "Folder doesn't exist", "Ok");
                return;
            }

            var allObjectPath = directoryInfo.GetFiles("*.prefab", SearchOption.TopDirectoryOnly);

            newCategory.catName = new DirectoryInfo(dataPath + targetPath).Name;
            RuntimePreviewGenerator.MarkTextureNonReadable = false;

            for (int i = 0; i < allObjectPath.Length; i++)
            {
                var prefabPath = allObjectPath[i].FullName;

                prefabPath = prefabPath.Replace("\\", "/");

                if (prefabPath.StartsWith(Application.dataPath))
                    prefabPath = "Assets" + prefabPath.Substring(Application.dataPath.Length);

                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                var placeable = prefab.GetComponent<IPlaceableObject>();

                if (placeable == null)
                    continue;

                RuntimePreviewGenerator.MarkTextureNonReadable = false;
                Color color = Color.black;
                ColorUtility.TryParseHtmlString("#2E2E2E", out color);
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
                    newCategory.Add(prefab, icon);

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
                }
            }

            if (newCategory.count <= 0)
            {
                EditorUtility.DisplayDialog("Error", "No placeable object in selected folder", "Ok");
                return;
            }

            _target.Add(newCategory);

            AssetDatabase.CreateAsset(newCategory, $"{targetPath}/{newCategory.catName}.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorGUIUtility.PingObject(newCategory);
            EditorUtility.SetDirty(newCategory);
            EditorUtility.SetDirty(_target);
        }
    }
}
#endif