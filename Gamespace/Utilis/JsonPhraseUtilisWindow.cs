#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class JsonPhraseUtilisWindow : EditorWindow
{
    private InputActionAsset _actionAsset;
    private JsonPhraseUtilis _phraser;
    public Vector2 scroll;
    
    private string _wrapper;
    
    [MenuItem("Utilis/Json wrapper resolver")]
    public static void Open()
    {
        JsonPhraseUtilisWindow window = GetWindow<JsonPhraseUtilisWindow>();
        window.titleContent = new GUIContent("Input Json Resolver");
        window.Show();
    }
    
    public void OnGUI()
    {
        if (ReferenceEquals(_phraser, null))
            _phraser = new JsonPhraseUtilis();
        
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("target input action asset", EditorStyles.boldLabel);
        _actionAsset = (InputActionAsset)EditorGUILayout.ObjectField(_actionAsset, typeof(InputActionAsset), false);
        if (GUILayout.Button("Load from clipboard"))
            _wrapper = GUIUtility.systemCopyBuffer;
        
        EditorGUILayout.EndVertical();

        var isLock = string.IsNullOrEmpty(_wrapper) || ReferenceEquals(_actionAsset, null);
        
        EditorGUI.BeginDisabledGroup(isLock);
        if (GUILayout.Button("Resolve"))
            GetPharsedJson();
        
        EditorGUI.EndDisabledGroup();
    }
    
    private void GetPharsedJson()
    {
        if (string.IsNullOrEmpty(_wrapper) || ReferenceEquals(_actionAsset, null))
            return;
        
        var json = _phraser.Convert(_wrapper);
        Debug.Log(json);
        _actionAsset.LoadFromJson(json);
    }
}
#endif