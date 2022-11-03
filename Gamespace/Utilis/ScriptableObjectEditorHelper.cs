#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Utilis
{
    public static class ScriptableObjectEditorHelper
    {
        public static void DrawHeader(string text)
        {
            EditorGUILayout.BeginVertical("ToolbarButton");
            GUILayout.Label(text, EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
        }
        public static void DrawSubHeader(string text)
        {
            EditorGUILayout.BeginVertical("Box");
            GUILayout.Label(text, EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
        }
        public static bool DrawButton(string buttonName)
        {
            return GUILayout.Button(buttonName, EditorStyles.miniButton);
        }
    }
}
#endif