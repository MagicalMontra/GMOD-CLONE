#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ExtendedPrefabProvider
{
    public static GameObject LoadObject(string name)
    {
        var format = "Assets/Modules/StandardUI/Prefab/{0}.prefab";
        var path = string.Format(format, name);
        GameObject obj = null;
        obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        return obj;
    }
}
#endif
