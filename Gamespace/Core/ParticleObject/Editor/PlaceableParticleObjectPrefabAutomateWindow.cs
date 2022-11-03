#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using Gamespace.Core.ObjectMode;
using Gamespace.Utilis;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Core.ParticleObject
{
    public class PlaceableParticleObjectPrefabAutomateWindow : EditorWindow
    {
        private PlaceType _type;
        private DefaultAsset _folder;
        private GameObject _moldObject;
        private GameObject _referenceObject;
        private List<string> _nameOffsets = new List<string>();
        private static List<GameObject> _models = new List<GameObject>();

        [MenuItem("Gamespace/Placeable/Create Particle Objects")]
        private static void Init()
        {
            _models.Clear();
            var window = GetWindow(typeof(PlaceableParticleObjectPrefabAutomateWindow));
            window.Show();
        }

        private void DropAreaGUI()
        {
            Event currentEvent = Event.current;
            Rect dropArea = GUILayoutUtility.GetRect(0f, 25, GUILayout.ExpandWidth(true));

            GUI.Box(dropArea, "Drop model prefabs here");

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
                            var go = (GameObject)draggedObject;

                            if (go == null)
                                continue;

                            _models.Add(go);
                        }
                    }

                    Event.current.Use();
                    break;
            }
        }
        private void OnGUI()
        {
            ScriptableObjectEditorHelper.DrawHeader("Placeable object creation");
            ScriptableObjectEditorHelper.DrawSubHeader("Target Folder");
            _folder = (DefaultAsset)EditorGUILayout.ObjectField(_folder, typeof(DefaultAsset), false);
            ScriptableObjectEditorHelper.DrawSubHeader("Remove implicit in name");
            for (int i = 0; i < _nameOffsets.Count; i++)
                _nameOffsets[i] = EditorGUILayout.TextField(_nameOffsets[i]);
            var addNameOffsetButton = ScriptableObjectEditorHelper.DrawButton("Add implicit to remove");
            if (addNameOffsetButton)
                _nameOffsets.Add("");

            ScriptableObjectEditorHelper.DrawSubHeader("Mold object");
            _type = (PlaceType)EditorGUILayout.EnumPopup(_type);
            _moldObject = (GameObject)EditorGUILayout.ObjectField(_moldObject, typeof(GameObject), false);
            
            ScriptableObjectEditorHelper.DrawSubHeader("Reference object");
            _referenceObject = (GameObject)EditorGUILayout.ObjectField(_referenceObject, typeof(GameObject), false);


            ScriptableObjectEditorHelper.DrawSubHeader("Models");

            DropAreaGUI();

            var createButton = ScriptableObjectEditorHelper.DrawButton("Create");

            if (createButton)
            {
                for (int i = 0; i < _models.Count; i++)
                {
                    if (_models[i] == null)
                        continue;

                    var moldObject = (GameObject)PrefabUtility.InstantiatePrefab(_moldObject);
                    moldObject.transform.position = Vector3.zero;

                    var name = _models[i].name;

                    for (int j = 0; j < _nameOffsets.Count; j++)
                        name = name.Replace(_nameOffsets[j], "");

                    moldObject.name = name;

                    var placeableObject = moldObject.GetComponent<IPlaceableObject>();
                    if (placeableObject == null)
                    {
                        Debug.LogWarning("Mold prefab doesn't have IPlaceableObject component attached to it");
                        EditorGUIUtility.PingObject(_moldObject);
                        break;
                    }

                    var actionGroup = moldObject.transform.Find("ActionGroup");

                    if (actionGroup is null)
                    {
                        Debug.LogWarning("Mold prefab doesn't have ActionGroup object in it");
                        EditorGUIUtility.PingObject(_moldObject);
                        break;
                    }

                    var referenceObject = (GameObject)PrefabUtility.InstantiatePrefab(_referenceObject, moldObject.transform);
                    referenceObject.name = "ModelGroup";
                    referenceObject.transform.localPosition = Vector3.zero;

                    var modelCollider = referenceObject.GetComponent<Collider>();

                    if (modelCollider == null)
                        continue;

                    var meshCollider = modelCollider as MeshCollider;

                    if (meshCollider != null)
                        meshCollider.convex = true;

                    var bottom = modelCollider.bounds.center.y + modelCollider.bounds.min.y;

                    if (bottom < referenceObject.transform.localPosition.y)
                        referenceObject.transform.position = new Vector3(0, bottom * -1, 0);

                    actionGroup.transform.position = modelCollider.bounds.center;

                    placeableObject.EditorSetup(_type, referenceObject, actionGroup);

                    var meshRenderers = new List<MeshRenderer>();

                    var meshRenderer = referenceObject.GetComponent<MeshRenderer>();

                    if (meshRenderer != null)
                        meshRenderers.Add(meshRenderer);

                    moldObject.GetComponentsInChildren<IMaterialSwapper>().ToList().ForEach(matSwapper => matSwapper.EditorAssignRenderer(meshRenderers.ToArray()));

                    var particleObject = (GameObject)PrefabUtility.InstantiatePrefab(_models[i], referenceObject.transform);
                    particleObject.transform.localPosition = Vector3.zero;
                    var particle = particleObject.GetComponent<ParticleSystem>();
                    
                    if (particle != null)
                        moldObject.GetComponentsInChildren<ParticleSwapper>().ToList().ForEach(particleSwapper => particleSwapper.SetEditorParticle(particle));

                    if (_folder != null)
                        PrefabUtility.SaveAsPrefabAsset(moldObject, AssetDatabase.GetAssetPath(_folder) + "/" + moldObject.name + ".prefab");
                }
            }

            for (int i = 0; i < _models.Count; i++)
            {
                _models[i] = (GameObject)EditorGUILayout.ObjectField(_models[i], typeof(GameObject), true);
            }
        }
    }
}
#endif