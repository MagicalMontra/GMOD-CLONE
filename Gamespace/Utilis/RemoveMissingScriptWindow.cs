#if UNITY_EDITOR
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Utilis
{
    public class RemoveMissingScriptWindow : EditorWindow
    {
        private DefaultAsset _targetFolder;
        
        [MenuItem("Gamespace/Utilis/Remove missing script")]
        private static void Init()
        {
            var window = GetWindow(typeof(RemoveMissingScriptWindow));
            window.Show();
        }
        private void OnGUI()
        {
            ScriptableObjectEditorHelper.DrawHeader("Remove missing script");
            _targetFolder = (DefaultAsset)EditorGUILayout.ObjectField(_targetFolder, typeof(DefaultAsset), false);
            var removeButton = ScriptableObjectEditorHelper.DrawButton("Remove");

            if (removeButton)
                RemoveMissingScripts();
        }

        private void RemoveMissingScripts()
        {
            var folderPath = AssetDatabase.GetAssetPath(_targetFolder);
            var dataPath = Application.dataPath.Replace("Assets", "");
            var folderInfo = new DirectoryInfo(dataPath + folderPath);
            var allObjectPath = folderInfo.GetFiles("*.prefab", SearchOption.AllDirectories);
            var prefabCount = 0;
            
            for (int i = 0; i < allObjectPath.Length; i++)
            {
                var prefabPath = allObjectPath[i].FullName;

                prefabPath = prefabPath.Replace("\\", "/");

                if (prefabPath.StartsWith(Application.dataPath))
                    prefabPath = "Assets" + prefabPath.Substring(Application.dataPath.Length);

                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                
                if (prefab == null)
                    continue;
                
                RemoveInChild(prefab);
                EditorUtility.SetDirty(prefab);
            }
            
            AssetDatabase.Refresh();
        }
        private void RemoveInChild(GameObject gameObject)
        {
            GameObjectUtility.RemoveMonoBehavioursWithMissingScript(gameObject);
            
            foreach (Transform childT in gameObject.transform)
            {
                RemoveInChild(childT.gameObject);
            }
        }
    }
}
#endif