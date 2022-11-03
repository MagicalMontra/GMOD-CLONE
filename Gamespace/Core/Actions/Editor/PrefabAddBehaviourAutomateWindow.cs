#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.ObjectMode;
using Gamespace.Utilis;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Core.Actions.Editor
{
    public class PrefabAddBehaviourAutomateWindow : EditorWindow
    {
        private static List<GameObject> _placeables = new List<GameObject>();
        private static List<GameObject> _actionBehaviours = new List<GameObject>();
        
        [MenuItem("Gamespace/Action/Add new action to placeables")]
        private static void Init()
        {
            _placeables.Clear();
            _actionBehaviours.Clear();
            var window = GetWindow(typeof(PrefabAddBehaviourAutomateWindow));
            window.Show();
        }
        private void OnGUI()
        {
            ScriptableObjectEditorHelper.DrawHeader("Add new action to placeables");
            EditorGUILayout.Space(10);
            DropPlaceableAreaGUI();
            DropActionBehaviourAreaGUI();
            var addButton = ScriptableObjectEditorHelper.DrawButton("Add");

            if (addButton)
            {
                for (int i = 0; i < _placeables.Count; i++)
                {
                    if (_placeables[i] is null)
                    {
                        Debug.LogWarning($"Index {i} is null");
                        continue;
                    }

                    var placeable = (GameObject)PrefabUtility.InstantiatePrefab(_placeables[i]);
                    
                    if (placeable is null)
                    {
                        Debug.LogWarning("Error on instantiate placeable");
                        continue;
                    }

                    
                    var actionGroup = placeable.transform.Find("ActionGroup");

                    if (actionGroup is null)
                    {
                        Debug.LogWarning($"{placeable.name} prefab doesn't have ActionGroup transform in its hierarchy");
                        continue;
                    }
                    
                    var modelGroup = placeable.transform.Find("ModelGroup");

                    if (modelGroup != null)
                        actionGroup.localPosition = modelGroup.localPosition;

                    for (int j = 0; j < _actionBehaviours.Count; j++)
                    {
                        var behaviour = (GameObject)PrefabUtility.InstantiatePrefab(_actionBehaviours[j], actionGroup);
                        behaviour.transform.localPosition = Vector3.zero;
                        behaviour.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    }

                    PrefabUtility.ApplyPrefabInstance(placeable, InteractionMode.AutomatedAction);
                    DestroyImmediate(placeable);
                }
            }
            
            ScriptableObjectEditorHelper.DrawSubHeader("Placeables");
            for (int i = 0; i < _placeables.Count; i++)
                EditorGUILayout.ObjectField(_placeables[i], typeof(GameObject), false);
            
            ScriptableObjectEditorHelper.DrawSubHeader("Action Behaviours");
            for (int i = 0; i < _actionBehaviours.Count; i++)
                EditorGUILayout.ObjectField(_actionBehaviours[i], typeof(GameObject), false);
        }
        private void DropPlaceableAreaGUI()
        {
            Event currentEvent = Event.current;
            Rect dropArea = GUILayoutUtility.GetRect(0f, 25, GUILayout.ExpandWidth(true));
            
            GUI.Box(dropArea, "Drop placeable prefabs here");

            switch (currentEvent.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(currentEvent.mousePosition))
                        break;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (currentEvent.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();
                        foreach (var draggedObject in DragAndDrop.objectReferences)
                        {
                            var go = (GameObject) draggedObject;
                            
                            if (go is null)
                                continue;

                            var placeable = go.GetComponent<IPlaceableObject>();

                            if (placeable is null)
                            {
                                Debug.LogWarning($"{go.name} prefab doesn't have IPlaceableObject component attached to it");
                                continue;
                            }
                            
                            _placeables.Add(go);
                        }
                    }
                    
                    Event.current.Use();
                    break;
            }
        }
        private void DropActionBehaviourAreaGUI()
        {
            Event currentEvent = Event.current;
            Rect dropArea = GUILayoutUtility.GetRect(0f, 25, GUILayout.ExpandWidth(true));
            
            GUI.Box(dropArea, "Drop action behaviour prefabs here");

            switch (currentEvent.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(currentEvent.mousePosition))
                        break;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (currentEvent.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();
                        foreach (var draggedObject in DragAndDrop.objectReferences)
                        {
                            var go = (GameObject) draggedObject;
                            
                            if (go is null)
                                continue;

                            var behaviour = go.GetComponent<IActionBehaviour>();

                            if (behaviour is null)
                            {
                                Debug.LogWarning($"{go.name} prefab doesn't have IActionBehaviour component attached to it");
                                continue;
                            }
                            
                            _actionBehaviours.Add(go);
                        }
                    }
                    
                    Event.current.Use();
                    break;
            }
        }
    }

}
#endif