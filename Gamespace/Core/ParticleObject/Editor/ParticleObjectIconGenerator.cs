#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Core.ParticleObject
{
    public class ParticleObjectIconGenerator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        
        [SerializeField] private float _delay = 0.1f;
        [SerializeField] private Vector3 _scale = Vector3.one;
        [SerializeField] private DefaultAsset _folder;
        [SerializeField] private Texture2D _missingIconTexture;
        [SerializeField] private GameObject _referenceObject;
        [SerializeField] private List<string> _nameOffsets = new List<string>();
        [SerializeField] private List<GameObject> _particles = new List<GameObject>();

        private async UniTask Snapshot(string name, GameObject model, ParticleSystem particle)
        {
            var main = particle.main;
            main.playOnAwake = false;
            particle.Play();

            await UniTask.Delay(Mathf.CeilToInt(_delay * 1000));
            
            particle.Pause();
            
            RuntimePreviewGenerator.MarkTextureNonReadable = false;
            Color color = Color.clear;

            if( color.a < 1f )
                GL.Clear(false, true, color);
            
            RenderTexture rt = new RenderTexture(512, 512, 24);
            _camera.targetTexture = rt;
            Texture2D icon = new Texture2D(512, 512, color.a < 1f ? TextureFormat.RGBA32 : TextureFormat.RGB24, false );
            _camera.Render();
            RenderTexture.active = rt;
            icon.ReadPixels(new Rect(0, 0, 512, 512), 0, 0);
            _camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);

            var dataPath = Application.dataPath.Replace("Assets", "");
            string iconPath = dataPath + "/" + AssetDatabase.GetAssetPath(_folder) + "/" + name + "_icon" + ".png";
            byte[] bytes = icon.EncodeToPNG();
            File.WriteAllBytes(iconPath, bytes);
            AssetDatabase.SaveAssets();

            if (iconPath.StartsWith(Application.dataPath))
                iconPath = "Assets" + iconPath.Substring(Application.dataPath.Length);

            AssetDatabase.Refresh();
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);

            if (icon != null)
            {
                AssetDatabase.ImportAsset(iconPath);
                var iconImporter = AssetImporter.GetAtPath(iconPath) as TextureImporter;

                if (iconImporter != null)
                {
                    iconImporter.textureType = TextureImporterType.Sprite;
                    AssetDatabase.WriteImportSettingsIfDirty(iconPath);
                    AssetDatabase.Refresh();
                }
            }

            Destroy(model.gameObject);
            
            await UniTask.Delay(100);
        }

        private async void Start()
        {
            for (int i = 0; i < _particles.Count; i++)
            {
                if (_particles[i] == null)
                    continue;

                var name = _particles[i].name;

                for (int j = 0; j < _nameOffsets.Count; j++)
                    name = name.Replace(_nameOffsets[j], "");

                var referenceObject = Instantiate(_referenceObject);
                referenceObject.transform.position = Vector3.zero;
                referenceObject.transform.localScale = _scale;
                var particleObject = (GameObject)PrefabUtility.InstantiatePrefab(_particles[i], referenceObject.transform);
                particleObject.transform.localPosition = Vector3.zero;
                var particle = particleObject.GetComponent<ParticleSystem>();
                    
                if (particle is null)
                    continue;

                await Snapshot(name, referenceObject, particle);
            }
        }
    }
}
#endif